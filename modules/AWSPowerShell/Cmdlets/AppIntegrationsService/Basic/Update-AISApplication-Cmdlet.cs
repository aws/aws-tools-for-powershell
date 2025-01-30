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
using Amazon.AppIntegrationsService;
using Amazon.AppIntegrationsService.Model;

namespace Amazon.PowerShell.Cmdlets.AIS
{
    /// <summary>
    /// Updates and persists an Application resource.
    /// </summary>
    [Cmdlet("Update", "AISApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("None or Amazon.AppIntegrationsService.Model.UpdateApplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppIntegrationsService.Model.UpdateApplicationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateAISApplicationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExternalUrlConfig_AccessUrl
        /// <summary>
        /// <para>
        /// <para>The URL to access the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationSourceConfig_ExternalUrlConfig_AccessUrl")]
        public System.String ExternalUrlConfig_AccessUrl { get; set; }
        #endregion
        
        #region Parameter ExternalUrlConfig_ApprovedOrigin
        /// <summary>
        /// <para>
        /// <para>Additional URLs to allow list if different than the access URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationSourceConfig_ExternalUrlConfig_ApprovedOrigins")]
        public System.String[] ExternalUrlConfig_ApprovedOrigin { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Application.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The configuration of events or requests that the application has access to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public System.String[] Permission { get; set; }
        #endregion
        
        #region Parameter Publication
        /// <summary>
        /// <para>
        /// <para>The events that the application publishes.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Publications has been replaced with Permissions")]
        [Alias("Publications")]
        public Amazon.AppIntegrationsService.Model.Publication[] Publication { get; set; }
        #endregion
        
        #region Parameter Subscription
        /// <summary>
        /// <para>
        /// <para>The events that the application subscribes.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Subscriptions has been replaced with Permissions")]
        [Alias("Subscriptions")]
        public Amazon.AppIntegrationsService.Model.Subscription[] Subscription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.UpdateApplicationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AISApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.UpdateApplicationResponse, UpdateAISApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExternalUrlConfig_AccessUrl = this.ExternalUrlConfig_AccessUrl;
            if (this.ExternalUrlConfig_ApprovedOrigin != null)
            {
                context.ExternalUrlConfig_ApprovedOrigin = new List<System.String>(this.ExternalUrlConfig_ApprovedOrigin);
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            if (this.Permission != null)
            {
                context.Permission = new List<System.String>(this.Permission);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Publication != null)
            {
                context.Publication = new List<Amazon.AppIntegrationsService.Model.Publication>(this.Publication);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Subscription != null)
            {
                context.Subscription = new List<Amazon.AppIntegrationsService.Model.Subscription>(this.Subscription);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.AppIntegrationsService.Model.UpdateApplicationRequest();
            
            
             // populate ApplicationSourceConfig
            var requestApplicationSourceConfigIsNull = true;
            request.ApplicationSourceConfig = new Amazon.AppIntegrationsService.Model.ApplicationSourceConfig();
            Amazon.AppIntegrationsService.Model.ExternalUrlConfig requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig = null;
            
             // populate ExternalUrlConfig
            var requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfigIsNull = true;
            requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig = new Amazon.AppIntegrationsService.Model.ExternalUrlConfig();
            System.String requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_AccessUrl = null;
            if (cmdletContext.ExternalUrlConfig_AccessUrl != null)
            {
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_AccessUrl = cmdletContext.ExternalUrlConfig_AccessUrl;
            }
            if (requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_AccessUrl != null)
            {
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig.AccessUrl = requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_AccessUrl;
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfigIsNull = false;
            }
            List<System.String> requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_ApprovedOrigin = null;
            if (cmdletContext.ExternalUrlConfig_ApprovedOrigin != null)
            {
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_ApprovedOrigin = cmdletContext.ExternalUrlConfig_ApprovedOrigin;
            }
            if (requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_ApprovedOrigin != null)
            {
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig.ApprovedOrigins = requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig_externalUrlConfig_ApprovedOrigin;
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfigIsNull = false;
            }
             // determine if requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig should be set to null
            if (requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfigIsNull)
            {
                requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig = null;
            }
            if (requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig != null)
            {
                request.ApplicationSourceConfig.ExternalUrlConfig = requestApplicationSourceConfig_applicationSourceConfig_ExternalUrlConfig;
                requestApplicationSourceConfigIsNull = false;
            }
             // determine if request.ApplicationSourceConfig should be set to null
            if (requestApplicationSourceConfigIsNull)
            {
                request.ApplicationSourceConfig = null;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Publication != null)
            {
                request.Publications = cmdletContext.Publication;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Subscription != null)
            {
                request.Subscriptions = cmdletContext.Subscription;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.AppIntegrationsService.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "UpdateApplication");
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
            public System.String ExternalUrlConfig_AccessUrl { get; set; }
            public List<System.String> ExternalUrlConfig_ApprovedOrigin { get; set; }
            public System.String Arn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Permission { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.AppIntegrationsService.Model.Publication> Publication { get; set; }
            [System.ObsoleteAttribute]
            public List<Amazon.AppIntegrationsService.Model.Subscription> Subscription { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.UpdateApplicationResponse, UpdateAISApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
