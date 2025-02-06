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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Returns the <a>RegexPatternSet</a> specified by <c>RegexPatternSetId</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFRegexPatternSet")]
    [OutputType("Amazon.WAF.Model.RegexPatternSet")]
    [AWSCmdlet("Calls the AWS WAF GetRegexPatternSet API operation.", Operation = new[] {"GetRegexPatternSet"}, SelectReturnType = typeof(Amazon.WAF.Model.GetRegexPatternSetResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.RegexPatternSet or Amazon.WAF.Model.GetRegexPatternSetResponse",
        "This cmdlet returns an Amazon.WAF.Model.RegexPatternSet object.",
        "The service call response (type Amazon.WAF.Model.GetRegexPatternSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAFRegexPatternSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegexPatternSetId
        /// <summary>
        /// <para>
        /// <para>The <c>RegexPatternSetId</c> of the <a>RegexPatternSet</a> that you want to get. <c>RegexPatternSetId</c>
        /// is returned by <a>CreateRegexPatternSet</a> and by <a>ListRegexPatternSets</a>.</para>
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
        public System.String RegexPatternSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegexPatternSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.GetRegexPatternSetResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.GetRegexPatternSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegexPatternSet";
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
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.GetRegexPatternSetResponse, GetWAFRegexPatternSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RegexPatternSetId = this.RegexPatternSetId;
            #if MODULAR
            if (this.RegexPatternSetId == null && ParameterWasBound(nameof(this.RegexPatternSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegexPatternSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.GetRegexPatternSetRequest();
            
            if (cmdletContext.RegexPatternSetId != null)
            {
                request.RegexPatternSetId = cmdletContext.RegexPatternSetId;
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
        
        private Amazon.WAF.Model.GetRegexPatternSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.GetRegexPatternSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "GetRegexPatternSet");
            try
            {
                #if DESKTOP
                return client.GetRegexPatternSet(request);
                #elif CORECLR
                return client.GetRegexPatternSetAsync(request).GetAwaiter().GetResult();
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
            public System.String RegexPatternSetId { get; set; }
            public System.Func<Amazon.WAF.Model.GetRegexPatternSetResponse, GetWAFRegexPatternSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegexPatternSet;
        }
        
    }
}
