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
    /// Returns an array of IP addresses currently being blocked by the <a>RateBasedRule</a>
    /// that is specified by the <code>RuleId</code>. The maximum number of managed keys that
    /// will be blocked is 10,000. If more than 10,000 addresses exceed the rate limit, the
    /// 10,000 addresses with the highest rates will be blocked.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WAFRRateBasedRuleManagedKey")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF Regional GetRateBasedRuleManagedKeys API operation.", Operation = new[] {"GetRateBasedRuleManagedKeys"}, SelectReturnType = typeof(Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWAFRRateBasedRuleManagedKeyCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para>The <code>RuleId</code> of the <a>RateBasedRule</a> for which you want to get a list
        /// of <code>ManagedKeys</code>. <code>RuleId</code> is returned by <a>CreateRateBasedRule</a>
        /// and by <a>ListRateBasedRules</a>.</para>
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
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter NextMarker
        /// <summary>
        /// <para>
        /// <para>A null value and not currently used. Do not include this in your request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextMarker $null' for the first call and '-NextMarker $AWSHistory.LastServiceResponse.NextMarker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedKeys'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse).
        /// Specifying the name of a property of type Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedKeys";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextMarker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse, GetWAFRRateBasedRuleManagedKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NextMarker = this.NextMarker;
            context.RuleId = this.RuleId;
            #if MODULAR
            if (this.RuleId == null && ParameterWasBound(nameof(this.RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysRequest();
            
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextMarker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "GetRateBasedRuleManagedKeys");
            try
            {
                #if DESKTOP
                return client.GetRateBasedRuleManagedKeys(request);
                #elif CORECLR
                return client.GetRateBasedRuleManagedKeysAsync(request).GetAwaiter().GetResult();
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
            public System.String NextMarker { get; set; }
            public System.String RuleId { get; set; }
            public System.Func<Amazon.WAFRegional.Model.GetRateBasedRuleManagedKeysResponse, GetWAFRRateBasedRuleManagedKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedKeys;
        }
        
    }
}
