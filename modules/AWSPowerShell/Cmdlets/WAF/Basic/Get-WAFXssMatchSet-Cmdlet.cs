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
    /// Returns the <a>XssMatchSet</a> that is specified by <code>XssMatchSetId</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAFXssMatchSet")]
    [OutputType("Amazon.WAF.Model.XssMatchSet")]
    [AWSCmdlet("Calls the AWS WAF GetXssMatchSet API operation.", Operation = new[] {"GetXssMatchSet"}, SelectReturnType = typeof(Amazon.WAF.Model.GetXssMatchSetResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.XssMatchSet or Amazon.WAF.Model.GetXssMatchSetResponse",
        "This cmdlet returns an Amazon.WAF.Model.XssMatchSet object.",
        "The service call response (type Amazon.WAF.Model.GetXssMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWAFXssMatchSetCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        #region Parameter XssMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>XssMatchSetId</code> of the <a>XssMatchSet</a> that you want to get. <code>XssMatchSetId</code>
        /// is returned by <a>CreateXssMatchSet</a> and by <a>ListXssMatchSets</a>.</para>
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
        public System.String XssMatchSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'XssMatchSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.GetXssMatchSetResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.GetXssMatchSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "XssMatchSet";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the XssMatchSetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^XssMatchSetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^XssMatchSetId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.GetXssMatchSetResponse, GetWAFXssMatchSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.XssMatchSetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.XssMatchSetId = this.XssMatchSetId;
            #if MODULAR
            if (this.XssMatchSetId == null && ParameterWasBound(nameof(this.XssMatchSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter XssMatchSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.GetXssMatchSetRequest();
            
            if (cmdletContext.XssMatchSetId != null)
            {
                request.XssMatchSetId = cmdletContext.XssMatchSetId;
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
        
        private Amazon.WAF.Model.GetXssMatchSetResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.GetXssMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "GetXssMatchSet");
            try
            {
                #if DESKTOP
                return client.GetXssMatchSet(request);
                #elif CORECLR
                return client.GetXssMatchSetAsync(request).GetAwaiter().GetResult();
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
            public System.String XssMatchSetId { get; set; }
            public System.Func<Amazon.WAF.Model.GetXssMatchSetResponse, GetWAFXssMatchSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.XssMatchSet;
        }
        
    }
}
