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
using Amazon.AppIntegrationsService;
using Amazon.AppIntegrationsService.Model;

namespace Amazon.PowerShell.Cmdlets.AIS
{
    /// <summary>
    /// This API is in preview release and subject to change.
    /// 
    ///  
    /// <para>
    /// Creates and persists an Application resource.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AISApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppIntegrationsService.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.AppIntegrationsService.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.AppIntegrationsService.Model.CreateApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAISApplicationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
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
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the application.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Publication
        /// <summary>
        /// <para>
        /// <para>The events that the application publishes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Publications")]
        public Amazon.AppIntegrationsService.Model.Publication[] Publication { get; set; }
        #endregion
        
        #region Parameter Subscription
        /// <summary>
        /// <para>
        /// <para>The events that the application subscribes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subscriptions")]
        public Amazon.AppIntegrationsService.Model.Subscription[] Subscription { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.AppIntegrationsService.Model.CreateApplicationResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AISApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.CreateApplicationResponse, NewAISApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExternalUrlConfig_AccessUrl = this.ExternalUrlConfig_AccessUrl;
            if (this.ExternalUrlConfig_ApprovedOrigin != null)
            {
                context.ExternalUrlConfig_ApprovedOrigin = new List<System.String>(this.ExternalUrlConfig_ApprovedOrigin);
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Publication != null)
            {
                context.Publication = new List<Amazon.AppIntegrationsService.Model.Publication>(this.Publication);
            }
            if (this.Subscription != null)
            {
                context.Subscription = new List<Amazon.AppIntegrationsService.Model.Subscription>(this.Subscription);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.AppIntegrationsService.Model.CreateApplicationRequest();
            
            
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Publication != null)
            {
                request.Publications = cmdletContext.Publication;
            }
            if (cmdletContext.Subscription != null)
            {
                request.Subscriptions = cmdletContext.Subscription;
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
        
        private Amazon.AppIntegrationsService.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public List<Amazon.AppIntegrationsService.Model.Publication> Publication { get; set; }
            public List<Amazon.AppIntegrationsService.Model.Subscription> Subscription { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.CreateApplicationResponse, NewAISApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
