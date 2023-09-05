using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.DTOs.MappingExtentions
{
    public static class CommentMappingExtentions
    {
        public static Comment MapToEntity(this CommentCreationDTO dto)
        {
            return new Comment
            {
                Content=dto.Content,
                Recommend=dto.Recommend,
            };
        }
    }
}