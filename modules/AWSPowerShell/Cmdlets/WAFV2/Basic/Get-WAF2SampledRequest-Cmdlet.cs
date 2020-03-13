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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// <note><para>
    /// This is the latest version of <b>AWS WAF</b>, named AWS WAFV2, released in November,
    /// 2019. For information, including how to migrate your AWS WAF resources from the prior
    /// release, see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. 
    /// </para></note><para>
    /// Gets detailed information about a specified number of requests--a sample--that AWS
    /// WAF randomly selects from among the first 5,000 requests that your AWS resource received
    /// during a time range that you choose. You can specify a sample size of up to 500 requests,
    /// and you can specify any time range in the previous three hours.
    /// </para><para><code>GetSampledRequests</code> returns a time range, which is usually the time range
    /// that you specified. However, if your resource (such as a CloudFront distribution)
    /// received 5,000 requests before the specified time range elapsed, <code>GetSampledRequests</code>
    /// returns an updated time range. This new time range indicates the actual period during
    /// which AWS WAF selected the requests in the sample.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAF2SampledRequest")]
    [OutputType("Amazon.WAFV2.Model.GetSampledRequestsResponse")]
    [AWSCmdlet("Calls the AWS WAF V2 GetSampledRequests API operation.", Operation = new[] {"GetSampledRequests"}, SelectReturnType = typeof(Amazon.WAFV2.Model.GetSampledRequestsResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.GetSampledRequestsResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.GetSampledRequestsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWAF2SampledRequestCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <code>GetSampledRequests</code> to return
        /// a sample of the requests that your AWS resource received. Specify the date and time
        /// in the following format: <code>"2016-09-27T14:50Z"</code>. You can specify any time
        /// range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter RuleMetricName
        /// <summary>
        /// <para>
        /// <para>The metric name assigned to the <code>Rule</code> or <code>RuleGroup</code> for which
        /// you want a sample of requests.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RuleMetricName { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for an AWS CloudFront distribution or for a regional application.
        /// A regional application can be an Application Load Balancer (ALB) or an API Gateway
        /// stage. </para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <code>--scope=CLOUDFRONT
        /// --region=us-east-1</code>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <code>GetSampledRequests</code>
        /// to return a sample of the requests that your AWS resource received. Specify the date
        /// and time in the following format: <code>"2016-09-27T14:50Z"</code>. You can specify
        /// any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter WebAclArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource name (ARN) of the <code>WebACL</code> for which you want a sample
        /// of requests.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WebAclArn { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The number of requests that you want AWS WAF to return from among the first 5,000
        /// requests that your AWS resource received during the time range. If your resource received
        /// fewer requests than the value of <code>MaxItems</code>, <code>GetSampledRequests</code>
        /// returns information about all of them. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxItems")]
        public System.Int64? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.GetSampledRequestsResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.GetSampledRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleMetricName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleMetricName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleMetricName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.GetSampledRequestsResponse, GetWAF2SampledRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleMetricName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxItem = this.MaxItem;
            #if MODULAR
            if (this.MaxItem == null && ParameterWasBound(nameof(this.MaxItem)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleMetricName = this.RuleMetricName;
            #if MODULAR
            if (this.RuleMetricName == null && ParameterWasBound(nameof(this.RuleMetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleMetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            #if MODULAR
            if (this.TimeWindow_EndTime == null && ParameterWasBound(nameof(this.TimeWindow_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            #if MODULAR
            if (this.TimeWindow_StartTime == null && ParameterWasBound(nameof(this.TimeWindow_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebAclArn = this.WebAclArn;
            #if MODULAR
            if (this.WebAclArn == null && ParameterWasBound(nameof(this.WebAclArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WebAclArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.WAFV2.Model.GetSampledRequestsRequest();
            
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.RuleMetricName != null)
            {
                request.RuleMetricName = cmdletContext.RuleMetricName;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            
             // populate TimeWindow
            var requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFV2.Model.TimeWindow();
            System.DateTime? requestTimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestTimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestTimeWindow_timeWindow_EndTime != null)
            {
                request.TimeWindow.EndTime = requestTimeWindow_timeWindow_EndTime.Value;
                requestTimeWindowIsNull = false;
            }
            System.DateTime? requestTimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestTimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestTimeWindow_timeWindow_StartTime != null)
            {
                request.TimeWindow.StartTime = requestTimeWindow_timeWindow_StartTime.Value;
                requestTimeWindowIsNull = false;
            }
             // determine if request.TimeWindow should be set to null
            if (requestTimeWindowIsNull)
            {
                request.TimeWindow = null;
            }
            if (cmdletContext.WebAclArn != null)
            {
                request.WebAclArn = cmdletContext.WebAclArn;
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
        
        private Amazon.WAFV2.Model.GetSampledRequestsResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.GetSampledRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "GetSampledRequests");
            try
            {
                #if DESKTOP
                return client.GetSampledRequests(request);
                #elif CORECLR
                return client.GetSampledRequestsAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? MaxItem { get; set; }
            public System.String RuleMetricName { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.String WebAclArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.GetSampledRequestsResponse, GetWAF2SampledRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
