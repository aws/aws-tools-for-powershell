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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Disable portfolio sharing through the Organizations service. This command will not
    /// delete your current shares, but prevents you from creating new shares throughout your
    /// organization. Current shares are not kept in sync with your organization structure
    /// if the structure changes after calling this API. Only the management account in the
    /// organization can call this API.
    /// 
    ///  
    /// <para>
    /// You cannot call this API if there are active delegated administrators in the organization.
    /// </para><para>
    /// Note that a delegated administrator is not authorized to invoke <code>DisableAWSOrganizationsAccess</code>.
    /// </para><important><para>
    /// If you share an Service Catalog portfolio in an organization within Organizations,
    /// and then disable Organizations access for Service Catalog, the portfolio access permissions
    /// will not sync with the latest changes to the organization structure. Specifically,
    /// accounts that you removed from the organization after disabling Service Catalog access
    /// will retain access to the previously shared portfolio.
    /// </para></important>
    /// </summary>
    [Cmdlet("Disable", "SCAWSOrganizationsAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog DisableAWSOrganizationsAccess API operation.", Operation = new[] {"DisableAWSOrganizationsAccess"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableSCAWSOrganizationsAccessCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-SCAWSOrganizationsAccess (DisableAWSOrganizationsAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse, DisableSCAWSOrganizationsAccessCmdlet>(Select) ??
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
            var request = new Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessRequest();
            
            
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
        
        private Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "DisableAWSOrganizationsAccess");
            try
            {
                #if DESKTOP
                return client.DisableAWSOrganizationsAccess(request);
                #elif CORECLR
                return client.DisableAWSOrganizationsAccessAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ServiceCatalog.Model.DisableAWSOrganizationsAccessResponse, DisableSCAWSOrganizationsAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
