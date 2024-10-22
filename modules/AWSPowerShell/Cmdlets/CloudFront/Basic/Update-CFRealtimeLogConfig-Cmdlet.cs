/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a real-time log configuration.
    /// 
    ///  
    /// <para>
    /// When you update a real-time log configuration, all the parameters are updated with
    /// the values provided in the request. You cannot update some parameters independent
    /// of others. To update a real-time log configuration:
    /// </para><ol><li><para>
    /// Call <c>GetRealtimeLogConfig</c> to get the current real-time log configuration.
    /// </para></li><li><para>
    /// Locally modify the parameters in the real-time log configuration that you want to
    /// update.
    /// </para></li><li><para>
    /// Call this API (<c>UpdateRealtimeLogConfig</c>) by providing the entire real-time log
    /// configuration, including the parameters that you modified and those that you didn't.
    /// </para></li></ol><para>
    /// You cannot update a real-time log configuration's <c>Name</c> or <c>ARN</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFRealtimeLogConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.RealtimeLogConfig")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateRealtimeLogConfig API operation.", Operation = new[] {"UpdateRealtimeLogConfig"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.RealtimeLogConfig or Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.RealtimeLogConfig object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFRealtimeLogConfigCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for this real-time log configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ARN { get; set; }
        #endregion
        
        #region Parameter EndPoint
        /// <summary>
        /// <para>
        /// <para>Contains information about the Amazon Kinesis data stream where you are sending real-time
        /// log data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndPoints")]
        public Amazon.CloudFront.Model.EndPoint[] EndPoint { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>A list of fields to include in each real-time log record.</para><para>For more information about fields, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/real-time-logs.html#understand-real-time-log-config-fields">Real-time
        /// log configuration fields</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Fields")]
        public System.String[] Field { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for this real-time log configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SamplingRate
        /// <summary>
        /// <para>
        /// <para>The sampling rate for this real-time log configuration. The sampling rate determines
        /// the percentage of viewer requests that are represented in the real-time log data.
        /// You must provide an integer between 1 and 100, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SamplingRate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RealtimeLogConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RealtimeLogConfig";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFRealtimeLogConfig (UpdateRealtimeLogConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse, UpdateCFRealtimeLogConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ARN = this.ARN;
            if (this.EndPoint != null)
            {
                context.EndPoint = new List<Amazon.CloudFront.Model.EndPoint>(this.EndPoint);
            }
            if (this.Field != null)
            {
                context.Field = new List<System.String>(this.Field);
            }
            context.Name = this.Name;
            context.SamplingRate = this.SamplingRate;
            
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
            var request = new Amazon.CloudFront.Model.UpdateRealtimeLogConfigRequest();
            
            if (cmdletContext.ARN != null)
            {
                request.ARN = cmdletContext.ARN;
            }
            if (cmdletContext.EndPoint != null)
            {
                request.EndPoints = cmdletContext.EndPoint;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SamplingRate != null)
            {
                request.SamplingRate = cmdletContext.SamplingRate.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateRealtimeLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateRealtimeLogConfig");
            try
            {
                #if DESKTOP
                return client.UpdateRealtimeLogConfig(request);
                #elif CORECLR
                return client.UpdateRealtimeLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ARN { get; set; }
            public List<Amazon.CloudFront.Model.EndPoint> EndPoint { get; set; }
            public List<System.String> Field { get; set; }
            public System.String Name { get; set; }
            public System.Int64? SamplingRate { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateRealtimeLogConfigResponse, UpdateCFRealtimeLogConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RealtimeLogConfig;
        }
        
    }
}
