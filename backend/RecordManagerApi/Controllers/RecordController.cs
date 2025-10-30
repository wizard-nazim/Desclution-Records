using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordManagerApi.Data;
using RecordManagerApi.DTOs;
using RecordManagerApi.Models;

namespace RecordManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RecordController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public RecordController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecordDto>>> GetRecords()
    {
        var records = await _context.RecordItems.ToListAsync();
        return _mapper.Map<List<RecordDto>>(records);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecordDto>> GetRecord(int id)
    {
        var record = await _context.RecordItems.FindAsync(id);
        if (record == null) return NotFound();
        return _mapper.Map<RecordDto>(record);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<RecordDto>> PostRecord([FromBody] CreateRecordDto dto)
    {
        var record = _mapper.Map<RecordItem>(dto);
        _context.RecordItems.Add(record);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, _mapper.Map<RecordDto>(record));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> PutRecord(int id, [FromBody] UpdateRecordDto dto)
    {
        var record = await _context.RecordItems.FindAsync(id);
        if (record == null) return NotFound();

        _mapper.Map(dto, record);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteRecord(int id)
    {
        var record = await _context.RecordItems.FindAsync(id);
        if (record == null) return NotFound();
        _context.RecordItems.Remove(record);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}