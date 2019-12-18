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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Adds or removes the specified license configurations for the specified AWS resource.
    /// 
    ///  
    /// <para>
    /// You can update the license specifications of AMIs, instances, and hosts. You cannot
    /// update the license specifications for launch templates and AWS CloudFormation templates,
    /// as they send license configurations to the operation that creates the resource.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LICMLicenseSpecificationsForResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS License Manager UpdateLicenseSpecificationsForResource API operation.", Operation = new[] {"UpdateLicenseSpecificationsForResource"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse))]
    [AWSCmdletOutput("None or Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLICMLicenseSpecificationsForResourceCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter AddLicenseSpecification
        /// <summary>
        /// <para>
        /// <para>ARNs of the license configurations to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddLicenseSpecifications")]
        public Amazon.LicenseManager.Model.LicenseSpecification[] AddLicenseSpecification { get; set; }
        #endregion
        
        #region Parameter RemoveLicenseSpecification
        /// <summary>
        /// <para>
        /// <para>ARNs of the license configurations to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveLicenseSpecifications")]
        public Amazon.LicenseManager.Model.LicenseSpecification[] RemoveLicenseSpecification { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the AWS resource.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMLicenseSpecificationsForResource (UpdateLicenseSpecificationsForResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse, UpdateLICMLicenseSpecificationsForResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddLicenseSpecification != null)
            {
                context.AddLicenseSpecification = new List<Amazon.LicenseManager.Model.LicenseSpecification>(this.AddLicenseSpecification);
            }
            if (this.RemoveLicenseSpecification != null)
            {
                context.RemoveLicenseSpecification = new List<Amazon.LicenseManager.Model.LicenseSpecification>(this.RemoveLicenseSpecification);
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceRequest();
            
            if (cmdletContext.AddLicenseSpecification != null)
            {
                request.AddLicenseSpecifications = cmdletContext.AddLicenseSpecification;
            }
            if (cmdletContext.RemoveLicenseSpecification != null)
            {
                request.RemoveLicenseSpecifications = cmdletContext.RemoveLicenseSpecification;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
            public List<Amazon.LicenseManager.Model.LicenseSpecification> AddLicenseSpecification { get; set; }
            public List<Amazon.LicenseManager.Model.LicenseSpecification> RemoveLicenseSpecification { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.LicenseManager.Model.UpdateLicenseSpecificationsForResourceResponse, UpdateLICMLicenseSpecificationsForResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
