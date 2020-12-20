using System.Collections.Generic;

namespace regalo_web.ViewModels
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }

        public List<GiftModel> GiftList { get; set; }
    }
}