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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Gets detailed information about a specified number of requests--a sample--that AWS
    /// WAF randomly selects from among the first 5,000 requests that your AWS resource received
    /// during a time range that you choose. You can specify a sample size of up to 500 requests,
    /// and you can specify any time range in the previous three hours.
    /// </para><para><c>GetSampledRequests</c> returns a time range, which is usually the time range that
    /// you specified. However, if your resource (such as a CloudFront distribution) received
    /// 5,000 requests before the specified time range elapsed, <c>GetSampledRequests</c>
    /// returns an updated time range. This new time range indicates the actual period during
    /// which AWS WAF selected the requests in the sample.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFRSampledRequestList")]
    [OutputType("Amazon.WAFRegional.Model.GetSampledRequestsResponse")]
    [AWSCmdlet("Calls the AWS WAF Regional GetSampledRequests API operation.", Operation = new[] {"GetSampledRequests"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.GetSampledRequestsResponse))]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.GetSampledRequestsResponse",
        "This cmdlet returns an Amazon.WAFRegional.Model.GetSampledRequestsResponse object containing multiple properties."
    )]
    public partial class GetWAFRSampledRequestListCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your AWS resource received. You must specify the date
        /// and time in Coordinated Universal Time (UTC) format. UTC format includes the special
        /// designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can specify any
        /// time range in the previous three hours.</para>
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
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para><c>RuleId</c> is one of three values:</para><ul><li><para>The <c>RuleId</c> of the <c>Rule</c> or the <c>RuleGroupId</c> of the <c>RuleGroup</c>
        /// for which you want <c>GetSampledRequests</c> to return a sample of requests.</para></li><li><para><c>Default_Action</c>, which causes <c>GetSampledRequests</c> to return a sample
        /// of the requests that didn't match any of the rules in the specified <c>WebACL</c>.</para></li></ul>
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
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your AWS resource received. You must specify the date
        /// and time in Coordinated Universal Time (UTC) format. UTC format includes the special
        /// designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can specify any
        /// time range in the previous three hours.</para>
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
        
        #region Parameter WebAclId
        /// <summary>
        /// <para>
        /// <para>The <c>WebACLId</c> of the <c>WebACL</c> for which you want <c>GetSampledRequests</c>
        /// to return a sample of requests.</para>
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
        public System.String WebAclId { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The number of requests that you want AWS WAF to return from among the first 5,000
        /// requests that your AWS resource received during the time range. If your resource received
        /// fewer requests than the value of <c>MaxItems</c>, <c>GetSampledRequests</c> returns
        /// information about all of them. </para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.GetSampledRequestsResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.GetSampledRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.GetSampledRequestsResponse, GetWAFRSampledRequestListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxItem = this.MaxItem;
            #if MODULAR
            if (this.MaxItem == null && ParameterWasBound(nameof(this.MaxItem)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleId = this.RuleId;
            #if MODULAR
            if (this.RuleId == null && ParameterWasBound(nameof(this.RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.WebAclId = this.WebAclId;
            #if MODULAR
            if (this.WebAclId == null && ParameterWasBound(nameof(this.WebAclId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebAclId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFRegional.Model.GetSampledRequestsRequest();
            
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
            }
            
             // populate TimeWindow
            var requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFRegional.Model.TimeWindow();
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
            if (cmdletContext.WebAclId != null)
            {
                request.WebAclId = cmdletContext.WebAclId;
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
        
        private Amazon.WAFRegional.Model.GetSampledRequestsResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.GetSampledRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "GetSampledRequests");
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
            public System.String RuleId { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.String WebAclId { get; set; }
            public System.Func<Amazon.WAFRegional.Model.GetSampledRequestsResponse, GetWAFRSampledRequestListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
