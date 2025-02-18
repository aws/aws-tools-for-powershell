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
using System.Threading;
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Retrieves information for the specified mobile SDK release, including release notes
    /// and tags.
    /// 
    ///  
    /// <para>
    /// The mobile SDK is not generally available. Customers who have access to the mobile
    /// SDK can use it to establish and manage WAF tokens for use in HTTP(S) requests from
    /// a mobile device to WAF. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-application-integration.html">WAF
    /// client application integration</a> in the <i>WAF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAF2MobileSdkRelease")]
    [OutputType("Amazon.WAFV2.Model.MobileSdkRelease")]
    [AWSCmdlet("Calls the AWS WAF V2 GetMobileSdkRelease API operation.", Operation = new[] {"GetMobileSdkRelease"}, SelectReturnType = typeof(Amazon.WAFV2.Model.GetMobileSdkReleaseResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.MobileSdkRelease or Amazon.WAFV2.Model.GetMobileSdkReleaseResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.MobileSdkRelease object.",
        "The service call response (type Amazon.WAFV2.Model.GetMobileSdkReleaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAF2MobileSdkReleaseCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The device platform.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Platform")]
        public Amazon.WAFV2.Platform Platform { get; set; }
        #endregion
        
        #region Parameter ReleaseVersion
        /// <summary>
        /// <para>
        /// <para>The release version. For the latest available version, specify <c>LATEST</c>.</para>
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
        public System.String ReleaseVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MobileSdkRelease'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.GetMobileSdkReleaseResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.GetMobileSdkReleaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MobileSdkRelease";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.GetMobileSdkReleaseResponse, GetWAF2MobileSdkReleaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReleaseVersion = this.ReleaseVersion;
            #if MODULAR
            if (this.ReleaseVersion == null && ParameterWasBound(nameof(this.ReleaseVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.GetMobileSdkReleaseRequest();
            
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.ReleaseVersion != null)
            {
                request.ReleaseVersion = cmdletContext.ReleaseVersion;
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
        
        private Amazon.WAFV2.Model.GetMobileSdkReleaseResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.GetMobileSdkReleaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "GetMobileSdkRelease");
            try
            {
                return client.GetMobileSdkReleaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.WAFV2.Platform Platform { get; set; }
            public System.String ReleaseVersion { get; set; }
            public System.Func<Amazon.WAFV2.Model.GetMobileSdkReleaseResponse, GetWAF2MobileSdkReleaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MobileSdkRelease;
        }
        
    }
}
