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
    /// Gets a real-time log configuration.
    /// 
    ///  
    /// <para>
    /// To get a real-time log configuration, you can provide the configuration's name or
    /// its Amazon Resource Name (ARN). You must provide at least one. If you provide both,
    /// CloudFront uses the name to identify the real-time log configuration to get.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFRealtimeLogConfig")]
    [OutputType("Amazon.CloudFront.Model.RealtimeLogConfig")]
    [AWSCmdlet("Calls the Amazon CloudFront GetRealtimeLogConfig API operation.", Operation = new[] {"GetRealtimeLogConfig"}, SelectReturnType = typeof(Amazon.CloudFront.Model.GetRealtimeLogConfigResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.RealtimeLogConfig or Amazon.CloudFront.Model.GetRealtimeLogConfigResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.RealtimeLogConfig object.",
        "The service call response (type Amazon.CloudFront.Model.GetRealtimeLogConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFRealtimeLogConfigCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the real-time log configuration to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ARN { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the real-time log configuration to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RealtimeLogConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.GetRealtimeLogConfigResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.GetRealtimeLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RealtimeLogConfig";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.GetRealtimeLogConfigResponse, GetCFRealtimeLogConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ARN = this.ARN;
            context.Name = this.Name;
            
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
            var request = new Amazon.CloudFront.Model.GetRealtimeLogConfigRequest();
            
            if (cmdletContext.ARN != null)
            {
                request.ARN = cmdletContext.ARN;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudFront.Model.GetRealtimeLogConfigResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.GetRealtimeLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "GetRealtimeLogConfig");
            try
            {
                #if DESKTOP
                return client.GetRealtimeLogConfig(request);
                #elif CORECLR
                return client.GetRealtimeLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.GetRealtimeLogConfigResponse, GetCFRealtimeLogConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RealtimeLogConfig;
        }
        
    }
}
