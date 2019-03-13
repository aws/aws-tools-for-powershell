/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Increases or decreases the stream's data retention period by the value that you specify.
    /// To indicate whether you want to increase or decrease the data retention period, specify
    /// the <code>Operation</code> parameter in the request body. In the request, you must
    /// specify either the <code>StreamName</code> or the <code>StreamARN</code>. 
    /// 
    ///  <note><para>
    /// The retention period that you specify replaces the current value.
    /// </para></note><para>
    /// This operation requires permission for the <code>KinesisVideo:UpdateDataRetention</code>
    /// action.
    /// </para><para>
    /// Changing the data retention period affects the data in the stream as follows:
    /// </para><ul><li><para>
    /// If the data retention period is increased, existing data is retained for the new retention
    /// period. For example, if the data retention period is increased from one hour to seven
    /// hours, all existing data is retained for seven hours.
    /// </para></li><li><para>
    /// If the data retention period is decreased, existing data is retained for the new retention
    /// period. For example, if the data retention period is decreased from seven hours to
    /// one hour, all existing data is retained for one hour, and any data older than one
    /// hour is deleted immediately.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "KVDataRetention", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams UpdateDataRetention API operation.", Operation = new[] {"UpdateDataRetention"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisVideo.Model.UpdateDataRetentionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKVDataRetentionCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the stream whose retention period you want to change. To get the version,
        /// call either the <code>DescribeStream</code> or the <code>ListStreams</code> API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter DataRetentionChangeInHour
        /// <summary>
        /// <para>
        /// <para>The retention period, in hours. The value you specify replaces the current value.
        /// The maximum value for this parameter is 87600 (ten years).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataRetentionChangeInHours")]
        public System.Int32 DataRetentionChangeInHour { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to increase or decrease the retention period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisVideo.UpdateDataRetentionOperation")]
        public Amazon.KinesisVideo.UpdateDataRetentionOperation Operation { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the stream whose retention period you want to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream whose retention period you want to change.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KVDataRetention (UpdateDataRetention)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CurrentVersion = this.CurrentVersion;
            if (ParameterWasBound("DataRetentionChangeInHour"))
                context.DataRetentionChangeInHours = this.DataRetentionChangeInHour;
            context.Operation = this.Operation;
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisVideo.Model.UpdateDataRetentionRequest();
            
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
            }
            if (cmdletContext.DataRetentionChangeInHours != null)
            {
                request.DataRetentionChangeInHours = cmdletContext.DataRetentionChangeInHours.Value;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operation = cmdletContext.Operation;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.KinesisVideo.Model.UpdateDataRetentionResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.UpdateDataRetentionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "UpdateDataRetention");
            try
            {
                #if DESKTOP
                return client.UpdateDataRetention(request);
                #elif CORECLR
                return client.UpdateDataRetentionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String CurrentVersion { get; set; }
            public System.Int32? DataRetentionChangeInHours { get; set; }
            public Amazon.KinesisVideo.UpdateDataRetentionOperation Operation { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
