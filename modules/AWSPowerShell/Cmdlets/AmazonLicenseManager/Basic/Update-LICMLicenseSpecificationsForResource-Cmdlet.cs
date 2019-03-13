/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Adds or removes license configurations for a specified AWS resource. This operation
    /// currently supports updating the license specifications of AMIs, instances, and hosts.
    /// Launch templates and AWS CloudFormation templates are not managed from this operation
    /// as those resources send the license configurations directly to a resource creation
    /// operation, such as <code>RunInstances</code>.
    /// </summary>
    [Cmdlet("Update", "LICMLicenseSpecificationsForResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS License Manager UpdateLicenseSpecificationsForResource API operation.", Operation = new[] {"UpdateLicenseSpecificationsForResource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ResourceArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLICMLicenseSpecificationsForResourceCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter AddLicenseSpecification
        /// <summary>
        /// <para>
        /// <para>License configuration ARNs to be added to a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddLicenseSpecifications")]
        public Amazon.LicenseManager.Model.LicenseSpecification[] AddLicenseSpecification { get; set; }
        #endregion
        
        #region Parameter RemoveLicenseSpecification
        /// <summary>
        /// <para>
        /// <para>License configuration ARNs to be removed from a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveLicenseSpecifications")]
        public Amazon.LicenseManager.Model.LicenseSpecification[] RemoveLicenseSpecification { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>ARN for an AWS server resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ResourceArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMLicenseSpecificationsForResource (UpdateLicenseSpecificationsForResource)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AddLicenseSpecification != null)
            {
                context.AddLicenseSpecifications = new List<Amazon.LicenseManager.Model.LicenseSpecification>(this.AddLicenseSpecification);
            }
            if (this.RemoveLicenseSpecification != null)
            {
                context.RemoveLicenseSpecifications = new List<Amazon.LicenseManager.Model.LicenseSpecification>(this.RemoveLicenseSpecification);
            }
            context.ResourceArn = this.ResourceArn;
            
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
            var request = new Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceRequest();
            
            if (cmdletContext.AddLicenseSpecifications != null)
            {
                request.AddLicenseSpecifications = cmdletContext.AddLicenseSpecifications;
            }
            if (cmdletContext.RemoveLicenseSpecifications != null)
            {
                request.RemoveLicenseSpecifications = cmdletContext.RemoveLicenseSpecifications;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ResourceArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "UpdateLicenseSpecificationsForResource");
            try
            {
                #if DESKTOP
                return client.UpdateLicenseSpecificationsForResource(request);
                #elif CORECLR
                return client.UpdateLicenseSpecificationsForResourceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LicenseManager.Model.LicenseSpecification> AddLicenseSpecifications { get; set; }
            public List<Amazon.LicenseManager.Model.LicenseSpecification> RemoveLicenseSpecifications { get; set; }
            public System.String ResourceArn { get; set; }
        }
        
    }
}
