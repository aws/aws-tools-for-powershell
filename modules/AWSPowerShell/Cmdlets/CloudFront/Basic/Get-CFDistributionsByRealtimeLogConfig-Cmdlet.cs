/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets a list of distributions that have a cache behavior that's associated with the
    /// specified real-time log configuration.
    /// 
    ///  
    /// <para>
    /// You can specify the real-time log configuration by its name or its Amazon Resource
    /// Name (ARN). You must provide at least one. If you provide both, CloudFront uses the
    /// name to identify the real-time log configuration to list distributions for.
    /// </para><para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFDistributionsByRealtimeLogConfig")]
    [OutputType("Amazon.CloudFront.Model.DistributionList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionsByRealtimeLogConfig API operation.", Operation = new[] {"ListDistributionsByRealtimeLogConfig"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionList or Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.DistributionList object.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFDistributionsByRealtimeLogConfigCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RealtimeLogConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the real-time log configuration whose associated
        /// distributions you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RealtimeLogConfigArn { get; set; }
        #endregion
        
        #region Parameter RealtimeLogConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the real-time log configuration whose associated distributions you want
        /// to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RealtimeLogConfigName { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// distributions. The response includes distributions in the list that occur after the
        /// marker. To get the next page of the list, set this field's value to the value of <c>NextMarker</c>
        /// from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distributions that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RealtimeLogConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RealtimeLogConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RealtimeLogConfigName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse, GetCFDistributionsByRealtimeLogConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RealtimeLogConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            context.RealtimeLogConfigArn = this.RealtimeLogConfigArn;
            context.RealtimeLogConfigName = this.RealtimeLogConfigName;
            
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
            var request = new Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
            }
            if (cmdletContext.RealtimeLogConfigArn != null)
            {
                request.RealtimeLogConfigArn = cmdletContext.RealtimeLogConfigArn;
            }
            if (cmdletContext.RealtimeLogConfigName != null)
            {
                request.RealtimeLogConfigName = cmdletContext.RealtimeLogConfigName;
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
        
        private Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionsByRealtimeLogConfig");
            try
            {
                #if DESKTOP
                return client.ListDistributionsByRealtimeLogConfig(request);
                #elif CORECLR
                return client.ListDistributionsByRealtimeLogConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public System.String RealtimeLogConfigArn { get; set; }
            public System.String RealtimeLogConfigName { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListDistributionsByRealtimeLogConfigResponse, GetCFDistributionsByRealtimeLogConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionList;
        }
        
    }
}
