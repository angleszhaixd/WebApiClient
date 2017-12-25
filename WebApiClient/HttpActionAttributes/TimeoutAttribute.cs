﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.Attributes
{
    /// <summary>
    /// 表示此请求的超时时间
    /// </summary>
    public class TimeoutAttribute : ApiActionAttribute
    {
        /// <summary>
        /// 获取超时时间的毫秒数
        /// </summary>
        public int Milliseconds { get; private set; }

        /// <summary>
        /// 请求的超时时间
        /// </summary>
        /// <param name="milliseconds">超时时间的毫秒数</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TimeoutAttribute(int milliseconds)
        {
            if (milliseconds <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Milliseconds = milliseconds;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public override Task BeforeRequestAsync(ApiActionContext context)
        {
            context.RequestMessage.Timeout = TimeSpan.FromMilliseconds(this.Milliseconds);
            return ApiTask.CompletedTask;
        }
    }
}