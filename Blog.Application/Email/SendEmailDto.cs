﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Email
{
    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
