using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsWebApplication.Models
{
    /// <summary>
    /// csv���������f�[�^�̃��f��
    /// </summary>
    public class Split
    {
        // long��Id�����f���ɂ͐�΂ɕK�v���Ƃ��J�G���ɋ�������C������
        // public long Id { get; set; }

        // �{�� 
        // ���O�͂Ȃ�ĕt���Ă������킩��񂩂���
        [Required]
        public IEnumerable<string> Text { get; set; }
    }
}