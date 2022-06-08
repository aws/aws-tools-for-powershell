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
using Amazon.MainframeModernization;
using Amazon.MainframeModernization.Model;

namespace Amazon.PowerShell.Cmdlets.AMM
{
    /// <summary>
    /// Updates an application and creates a new version.
    /// </summary>
    [Cmdlet("Update", "AMMApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the M2 UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.MainframeModernization.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("System.Int32 or Amazon.MainframeModernization.Model.UpdateApplicationResponse",
        "This cmdlet returns a System.Int32 object.",
        "The service call response (type Amazon.MainframeModernization.Model.UpdateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMMApplicationCmdlet : AmazonMainframeModernizationClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the application you want to update.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Definition_Content
        /// <summary>
        /// <para>
        /// <para>The content of the application definition. This is a JSON object that contains the
        /// resource configuration/definitions that identify an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Definition_Content { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersion
        /// <summary>
        /// <para>
        /// <para>The current version of the application to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? CurrentApplicationVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Definition_S3Location
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that contains the application definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Definition_S3Location { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MainframeModernization.Model.UpdateApplicationResponse).
        /// Specifying the name of a property of type Amazon.MainframeModernization.Model.UpdateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationVersion";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMMApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MainframeModernization.Model.UpdateApplicationResponse, UpdateAMMApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentApplicationVersion = this.CurrentApplicationVersion;
            #if MODULAR
            if (this.CurrentApplicationVersion == null && ParameterWasBound(nameof(this.CurrentApplicationVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentApplicationVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Definition_Content = this.Definition_Content;
            context.Definition_S3Location = this.Definition_S3Location;
            context.Description = this.Description;
            
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
            var request = new Amazon.MainframeModernization.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.CurrentApplicationVersion != null)
            {
                request.CurrentApplicationVersion = cmdletContext.CurrentApplicationVersion.Value;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.MainframeModernization.Model.Definition();
            System.String requestDefinition_definition_Content = null;
            if (cmdletContext.Definition_Content != null)
            {
                requestDefinition_definition_Content = cmdletContext.Definition_Content;
            }
            if (requestDefinition_definition_Content != null)
            {
                request.Definition.Content = requestDefinition_definition_Content;
                requestDefinitionIsNull = false;
            }
            System.String requestDefinition_definition_S3Location = null;
            if (cmdletContext.Definition_S3Location != null)
            {
                requestDefinition_definition_S3Location = cmdletContext.Definition_S3Location;
            }
            if (requestDefinition_definition_S3Location != null)
            {
                request.Definition.S3Location = requestDefinition_definition_S3Location;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.MainframeModernization.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonMainframeModernization client, Amazon.MainframeModernization.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "M2", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Int32? CurrentApplicationVersion { get; set; }
            public System.String Definition_Content { get; set; }
            public System.String Definition_S3Location { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.MainframeModernization.Model.UpdateApplicationResponse, UpdateAMMApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationVersion;
        }
        
    }
}
