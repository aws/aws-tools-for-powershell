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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Lists license asset rulesets.
    /// </summary>
    [Cmdlet("Get", "LICMLicenseAssetRulesetList")]
    [OutputType("Amazon.LicenseManager.Model.LicenseAssetRuleset")]
    [AWSCmdlet("Calls the AWS License Manager ListLicenseAssetRulesets API operation.", Operation = new[] {"ListLicenseAssetRulesets"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.LicenseAssetRuleset or Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse",
        "This cmdlet returns a collection of Amazon.LicenseManager.Model.LicenseAssetRuleset objects.",
        "The service call response (type Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLICMLicenseAssetRulesetListCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters to scope the results. Following filters are supported</para><ul><li><para><c>Name</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LicenseManager.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ShowAWSManagedLicenseAssetRuleset
        /// <summary>
        /// <para>
        /// <para>Specifies whether to show License Manager managed license asset rulesets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ShowAWSManagedLicenseAssetRulesets")]
        public System.Boolean? ShowAWSManagedLicenseAssetRuleset { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return in a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token for the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseAssetRulesets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseAssetRulesets";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ShowAWSManagedLicenseAssetRuleset parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ShowAWSManagedLicenseAssetRuleset' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ShowAWSManagedLicenseAssetRuleset' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse, GetLICMLicenseAssetRulesetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ShowAWSManagedLicenseAssetRuleset;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LicenseManager.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ShowAWSManagedLicenseAssetRuleset = this.ShowAWSManagedLicenseAssetRuleset;
            
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
            var request = new Amazon.LicenseManager.Model.ListLicenseAssetRulesetsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ShowAWSManagedLicenseAssetRuleset != null)
            {
                request.ShowAWSManagedLicenseAssetRulesets = cmdletContext.ShowAWSManagedLicenseAssetRuleset.Value;
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
        
        private Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.ListLicenseAssetRulesetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "ListLicenseAssetRulesets");
            try
            {
                #if DESKTOP
                return client.ListLicenseAssetRulesets(request);
                #elif CORECLR
                return client.ListLicenseAssetRulesetsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LicenseManager.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? ShowAWSManagedLicenseAssetRuleset { get; set; }
            public System.Func<Amazon.LicenseManager.Model.ListLicenseAssetRulesetsResponse, GetLICMLicenseAssetRulesetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseAssetRulesets;
        }
        
    }
}
