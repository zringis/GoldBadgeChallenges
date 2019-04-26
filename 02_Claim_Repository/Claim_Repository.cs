using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repository
{
    public class Claim_Repository
    {
        private Queue<ClaimContent> _claims = new Queue<ClaimContent>();

        public void AddToQueue(ClaimContent claim)
        {
            _claims.Enqueue(claim);
        }
        public ClaimContent DealWithClaim()
        {
            ClaimContent nextClaim = _claims.Dequeue();
            return nextClaim;
        }
        public ClaimContent ViewNextClaim()
        {
            
             return _claims.Peek();
            
        }
        public Queue<ClaimContent> GetClaimQueue()
        {
            return _claims;
        }
        public bool HasContent()
        {
            bool hasContent = false;
            if(_claims.Count >= 1)
            {
                hasContent = true;
            }
            else
            {
                hasContent = false;
            }
            return hasContent;
        }
        public int GetClaimNumber()
        {
            int claimNumber;
            if (_claims.Count == 0)
            {
                claimNumber = 1;
            }
            else
            {
                claimNumber = _claims.Peek().ClaimNumber + _claims.Count;
            }
            return claimNumber;
        }
    }
}
