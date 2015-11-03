/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Increases the stream's retention period, which is the length of time data records
    /// are accessible after they are added to the stream. The maximum value of a stream’s
    /// retention period is 168 hours (7 days).
    /// 
    ///  
    /// <para>
    /// Upon choosing a longer stream retention period, this operation will increase the time
    /// period records are accessible that have not yet expired. However, it will not make
    /// previous data that has expired (older than the stream’s previous retention period)
    /// accessible after the operation has been called. For example, if a stream’s retention
    /// period is set to 24 hours and is increased to 168 hours, any data that is older than
    /// 24 hours will remain inaccessible to consumer applications.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "KINStreamRetentionPeriodIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the IncreaseStreamRetentionPeriod operation against AWS Kinesis.", Operation = new[] {"IncreaseStreamRetentionPeriod"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RequestKINStreamRetentionPeriodIncreaseCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter RetentionPeriodHour
        /// <summary>
        /// <para>
        /// <para>The new retention period of the stream, in hours. Must be more than the current retention
        /// period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetentionPeriodHours")]
        public System.Int32 RetentionPeriodHour { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-KINStreamRetentionPeriodIncrease (IncreaseStreamRetentionPeriod)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("RetentionPeriodHour"))
                context.RetentionPeriodHours = this.RetentionPeriodHour;
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodRequest();
            
            if (cmdletContext.RetentionPeriodHours != null)
            {
                request.RetentionPeriodHours = cmdletContext.RetentionPeriodHours.Value;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.IncreaseStreamRetentionPeriod(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StreamName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? RetentionPeriodHours { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
