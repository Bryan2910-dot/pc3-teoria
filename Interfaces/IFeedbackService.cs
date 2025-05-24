using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pc3_teoria.Models;

namespace pc3_teoria.Interfaces
{
    public interface IFeedbackService
    {
        Task<bool> AddFeedbackAsync(Feedback feedback);
        Task<List<Feedback>> GetFeedbacksAsync();
        Task<bool> HasFeedbackForPostAsync(int postId);
    }
}