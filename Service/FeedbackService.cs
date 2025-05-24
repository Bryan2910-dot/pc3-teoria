using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pc3_teoria.Data;
using pc3_teoria.Interfaces;
using pc3_teoria.Models;

namespace pc3_teoria.Service
{
    public class FeedbackService : IFeedbackService {
    private readonly ApplicationDbContext _context;

    public FeedbackService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<bool> AddFeedbackAsync(Feedback feedback) {
        if (await _context.Feedbacks.AnyAsync(f => f.PostId == feedback.PostId)) return false;
        feedback.Fecha = DateTime.Now;
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Feedback>> GetFeedbacksAsync() {
        return await _context.Feedbacks.ToListAsync();
    }

    public async Task<bool> HasFeedbackForPostAsync(int postId) {
        return await _context.Feedbacks.AnyAsync(f => f.PostId == postId);
    }
}

}