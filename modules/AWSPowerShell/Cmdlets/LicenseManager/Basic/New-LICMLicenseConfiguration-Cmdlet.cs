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
    /// Creates a new license configuration object. A license configuration is an abstraction
    /// of a customer license agreement that can be consumed and enforced by License Manager.
    /// Components include specifications for the license type (licensing by instance, socket,
    /// CPU, or VCPU), tenancy (shared tenancy, Amazon EC2 Dedicated Instance, Amazon EC2
    /// Dedicated Host, or any of these), host affinity (how long a VM must be associated
    /// with a host), the number of licenses purchased and used.
    /// </summary>
    [Cmdlet("New", "LICMLicenseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicenseConfiguration API operation.", Operation = new[] {"CreateLicenseConfiguration"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLICMLicenseConfigurationCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-friendly description of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LicenseCount
        /// <summary>
        /// <para>
        /// <para>Number of licenses managed by the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LicenseCount { get; set; }
        #endregion
        
        #region Parameter LicenseCountHardLimit
        /// <summary>
        /// <para>
        /// <para>Flag indicating whether hard or soft license enforcement is used. Exceeding a hard
        /// limit results in the blocked deployment of new instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LicenseCountHardLimit { get; set; }
        #endregion
        
        #region Parameter LicenseCountingType
        /// <summary>
        /// <para>
        /// <para>Dimension to use to track the license inventory.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LicenseManager.LicenseCountingType")]
        public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
        #endregion
        
        #region Parameter LicenseRule
        /// <summary>
        /// <para>
        /// <para>Array of configured License Manager rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseRules")]
        public System.String[] LicenseRule { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the license configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the resources during launch. You can only tag instances and volumes
        /// on launch. The specified tags are applied to all instances or volumes that are created
        /// during launch. To tag a resource after it has been created, see CreateTags .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LicenseManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseConfigurationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicenseConfiguration (CreateLicenseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse, NewLICMLicenseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.LicenseCount = this.LicenseCount;
            context.LicenseCountHardLimit = this.LicenseCountHardLimit;
            context.LicenseCountingType = this.LicenseCountingType;
            #if MODULAR
            if (this.LicenseCountingType == null && ParameterWasBound(nameof(this.LicenseCountingType)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseCountingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LicenseRule != null)
            {
                context.LicenseRule = new List<System.String>(this.LicenseRule);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LicenseManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LicenseCount != null)
            {
                request.LicenseCount = cmdletContext.LicenseCount.Value;
            }
            if (cmdletContext.LicenseCountHardLimit != null)
            {
                request.LicenseCountHardLimit = cmdletContext.LicenseCountHardLimit.Value;
            }
            if (cmdletContext.LicenseCountingType != null)
            {
                request.LicenseCountingType = cmdletContext.LicenseCountingType;
            }
            if (cmdletContext.LicenseRule != null)
            {
                request.LicenseRules = cmdletContext.LicenseRule;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicenseConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateLicenseConfiguration(request);
                #elif CORECLR
                return client.CreateLicenseConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Int64? LicenseCount { get; set; }
            public System.Boolean? LicenseCountHardLimit { get; set; }
            public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
            public List<System.String> LicenseRule { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LicenseManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse, NewLICMLicenseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseConfigurationArn;
        }
        
    }
}
