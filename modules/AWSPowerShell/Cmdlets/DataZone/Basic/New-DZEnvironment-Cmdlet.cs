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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Create an Amazon DataZone environment.
    /// </summary>
    [Cmdlet("New", "DZEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateEnvironmentResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateEnvironmentResponse object containing multiple properties."
    )]
    public partial class NewDZEnvironmentCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentOrder
        /// <summary>
        /// <para>
        /// <para>The deployment order of the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentOrder { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon DataZone environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain in which the environment is created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the account in which the environment is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentAccountRegion
        /// <summary>
        /// <para>
        /// <para>The region of the account in which the environment is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentAccountRegion { get; set; }
        #endregion
        
        #region Parameter EnvironmentBlueprintIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the blueprint with which the environment is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentBlueprintIdentifier { get; set; }
        #endregion
        
        #region Parameter EnvironmentConfigurationId
        /// <summary>
        /// <para>
        /// <para>The configuration ID of the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentConfigurationId { get; set; }
        #endregion
        
        #region Parameter EnvironmentProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the environment profile that is used to create this Amazon DataZone
        /// environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter GlossaryTerm
        /// <summary>
        /// <para>
        /// <para>The glossary terms that can be used in this Amazon DataZone environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlossaryTerms")]
        public System.String[] GlossaryTerm { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon DataZone environment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone project in which this environment is created.</para>
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
        public System.String ProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter UserParameter
        /// <summary>
        /// <para>
        /// <para>The user parameters of this Amazon DataZone environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserParameters")]
        public Amazon.DataZone.Model.EnvironmentParameter[] UserParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectIdentifier' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateEnvironmentResponse, NewDZEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeploymentOrder = this.DeploymentOrder;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentAccountIdentifier = this.EnvironmentAccountIdentifier;
            context.EnvironmentAccountRegion = this.EnvironmentAccountRegion;
            context.EnvironmentBlueprintIdentifier = this.EnvironmentBlueprintIdentifier;
            context.EnvironmentConfigurationId = this.EnvironmentConfigurationId;
            context.EnvironmentProfileIdentifier = this.EnvironmentProfileIdentifier;
            if (this.GlossaryTerm != null)
            {
                context.GlossaryTerm = new List<System.String>(this.GlossaryTerm);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectIdentifier = this.ProjectIdentifier;
            #if MODULAR
            if (this.ProjectIdentifier == null && ParameterWasBound(nameof(this.ProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserParameter != null)
            {
                context.UserParameter = new List<Amazon.DataZone.Model.EnvironmentParameter>(this.UserParameter);
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
            var request = new Amazon.DataZone.Model.CreateEnvironmentRequest();
            
            if (cmdletContext.DeploymentOrder != null)
            {
                request.DeploymentOrder = cmdletContext.DeploymentOrder.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EnvironmentAccountIdentifier != null)
            {
                request.EnvironmentAccountIdentifier = cmdletContext.EnvironmentAccountIdentifier;
            }
            if (cmdletContext.EnvironmentAccountRegion != null)
            {
                request.EnvironmentAccountRegion = cmdletContext.EnvironmentAccountRegion;
            }
            if (cmdletContext.EnvironmentBlueprintIdentifier != null)
            {
                request.EnvironmentBlueprintIdentifier = cmdletContext.EnvironmentBlueprintIdentifier;
            }
            if (cmdletContext.EnvironmentConfigurationId != null)
            {
                request.EnvironmentConfigurationId = cmdletContext.EnvironmentConfigurationId;
            }
            if (cmdletContext.EnvironmentProfileIdentifier != null)
            {
                request.EnvironmentProfileIdentifier = cmdletContext.EnvironmentProfileIdentifier;
            }
            if (cmdletContext.GlossaryTerm != null)
            {
                request.GlossaryTerms = cmdletContext.GlossaryTerm;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectIdentifier != null)
            {
                request.ProjectIdentifier = cmdletContext.ProjectIdentifier;
            }
            if (cmdletContext.UserParameter != null)
            {
                request.UserParameters = cmdletContext.UserParameter;
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
        
        private Amazon.DataZone.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateEnvironment(request);
                #elif CORECLR
                return client.CreateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DeploymentOrder { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EnvironmentAccountIdentifier { get; set; }
            public System.String EnvironmentAccountRegion { get; set; }
            public System.String EnvironmentBlueprintIdentifier { get; set; }
            public System.String EnvironmentConfigurationId { get; set; }
            public System.String EnvironmentProfileIdentifier { get; set; }
            public List<System.String> GlossaryTerm { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectIdentifier { get; set; }
            public List<Amazon.DataZone.Model.EnvironmentParameter> UserParameter { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateEnvironmentResponse, NewDZEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
