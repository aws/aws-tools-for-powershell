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
    /// Lists license configurations for an organization.
    /// </summary>
    [Cmdlet("Get", "LICMLicenseConfigurationsForOrganizationList")]
    [OutputType("Amazon.LicenseManager.Model.LicenseConfiguration")]
    [AWSCmdlet("Calls the AWS License Manager ListLicenseConfigurationsForOrganization API operation.", Operation = new[] {"ListLicenseConfigurationsForOrganization"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.LicenseConfiguration or Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse",
        "This cmdlet returns a collection of Amazon.LicenseManager.Model.LicenseConfiguration objects.",
        "The service call response (type Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLICMLicenseConfigurationsForOrganizationListCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters to scope the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LicenseManager.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter LicenseConfigurationArn
        /// <summary>
        /// <para>
        /// <para>License configuration ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseConfigurationArns")]
        public System.String[] LicenseConfigurationArn { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseConfigurations";
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
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse, GetLICMLicenseConfigurationsForOrganizationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LicenseManager.Model.Filter>(this.Filter);
            }
            if (this.LicenseConfigurationArn != null)
            {
                context.LicenseConfigurationArn = new List<System.String>(this.LicenseConfigurationArn);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.LicenseConfigurationArn != null)
            {
                request.LicenseConfigurationArns = cmdletContext.LicenseConfigurationArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "ListLicenseConfigurationsForOrganization");
            try
            {
                #if DESKTOP
                return client.ListLicenseConfigurationsForOrganization(request);
                #elif CORECLR
                return client.ListLicenseConfigurationsForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> LicenseConfigurationArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LicenseManager.Model.ListLicenseConfigurationsForOrganizationResponse, GetLICMLicenseConfigurationsForOrganizationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseConfigurations;
        }
        
    }
}
