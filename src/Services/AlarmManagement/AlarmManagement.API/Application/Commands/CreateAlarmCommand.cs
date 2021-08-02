using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    public class CreateAlarmCommand : IRequest<Guid>
    {
        /// <summary>
        /// 告警发生时间
        /// </summary>
        public DateTime OccurrenceTime { get; set; }
        /// <summary>
        /// 告警类别ID
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// 告警级别ID
        /// </summary>
        public Guid LevelId { get; set; }
        /// <summary>
        /// 告警名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 告警描述
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 告警详情
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 外部事件ID
        /// </summary>
        [Required(ErrorMessage = "事件ID不能为空")]
        public string EventId { get; set; }
    }

}
