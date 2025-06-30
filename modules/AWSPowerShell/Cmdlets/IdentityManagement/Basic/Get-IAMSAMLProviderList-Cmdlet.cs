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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Lists the SAML provider resource objects defined in IAM in the account. IAM resource-listing
    /// operations return a subset of the available attributes for the resource. For example,
    /// this operation does not return tags, even though they are an attribute of the returned
    /// object. To view all of the information for a SAML provider, see <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_GetSAMLProvider.html">GetSAMLProvider</a>.
    /// 
    ///  <important><para>
    ///  This operation requires <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
    /// Version 4</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "IAMSAMLProviderList")]
    [OutputType("Amazon.IdentityManagement.Model.SAMLProviderListEntry")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ListSAMLProviders API operation.", Operation = new[] {"ListSAMLProviders"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.ListSAMLProvidersResponse), LegacyAlias="Get-IAMSAMLProviders")]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.SAMLProviderListEntry or Amazon.IdentityManagement.Model.ListSAMLProvidersResponse",
        "This cmdlet returns a collection of Amazon.IdentityManagement.Model.SAMLProviderListEntry objects.",
        "The service call response (type Amazon.IdentityManagement.Model.ListSAMLProvidersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMSAMLProviderListCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SAMLProviderList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.ListSAMLProvidersResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.ListSAMLProvidersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SAMLProviderList";
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
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.ListSAMLProvidersResponse, GetIAMSAMLProviderListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.IdentityManagement.Model.ListSAMLProvidersRequest();
            
            
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
        
        private Amazon.IdentityManagement.Model.ListSAMLProvidersResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.ListSAMLProvidersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "ListSAMLProviders");
            try
            {
                #if DESKTOP
                return client.ListSAMLProviders(request);
                #elif CORECLR
                return client.ListSAMLProvidersAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IdentityManagement.Model.ListSAMLProvidersResponse, GetIAMSAMLProviderListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SAMLProviderList;
        }
        
    }
}
