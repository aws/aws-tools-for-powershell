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
    /// Creates and persists a DataIntegration resource.
    /// 
    ///  <note><para>
    /// You cannot create a DataIntegration association for a DataIntegration that has been
    /// previously associated. Use a different DataIntegration, or recreate the DataIntegration
    /// using the <code>CreateDataIntegration</code> API.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AISDataIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service CreateDataIntegration API operation.", Operation = new[] {"CreateDataIntegration"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAISDataIntegrationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the DataIntegration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_FirstExecutionFrom
        /// <summary>
        /// <para>
        /// <para>The start date for objects to import in the first flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_FirstExecutionFrom { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para>The KMS key for the DataIntegration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the DataIntegration.</para>
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
        
        #region Parameter ScheduleConfig_Object
        /// <summary>
        /// <para>
        /// <para>The name of the object to pull from the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_Object { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>How often the data should be pulled from data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter SourceURI
        /// <summary>
        /// <para>
        /// <para>The URI of the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceURI { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags.</para>
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
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse).
        /// Specifying the name of a property of type Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AISDataIntegration (CreateDataIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse, NewAISDataIntegrationCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KmsKey = this.KmsKey;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleConfig_FirstExecutionFrom = this.ScheduleConfig_FirstExecutionFrom;
            context.ScheduleConfig_Object = this.ScheduleConfig_Object;
            context.ScheduleConfig_ScheduleExpression = this.ScheduleConfig_ScheduleExpression;
            context.SourceURI = this.SourceURI;
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
            var request = new Amazon.AppIntegrationsService.Model.CreateDataIntegrationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ScheduleConfig
            var requestScheduleConfigIsNull = true;
            request.ScheduleConfig = new Amazon.AppIntegrationsService.Model.ScheduleConfiguration();
            System.String requestScheduleConfig_scheduleConfig_FirstExecutionFrom = null;
            if (cmdletContext.ScheduleConfig_FirstExecutionFrom != null)
            {
                requestScheduleConfig_scheduleConfig_FirstExecutionFrom = cmdletContext.ScheduleConfig_FirstExecutionFrom;
            }
            if (requestScheduleConfig_scheduleConfig_FirstExecutionFrom != null)
            {
                request.ScheduleConfig.FirstExecutionFrom = requestScheduleConfig_scheduleConfig_FirstExecutionFrom;
                requestScheduleConfigIsNull = false;
            }
            System.String requestScheduleConfig_scheduleConfig_Object = null;
            if (cmdletContext.ScheduleConfig_Object != null)
            {
                requestScheduleConfig_scheduleConfig_Object = cmdletContext.ScheduleConfig_Object;
            }
            if (requestScheduleConfig_scheduleConfig_Object != null)
            {
                request.ScheduleConfig.Object = requestScheduleConfig_scheduleConfig_Object;
                requestScheduleConfigIsNull = false;
            }
            System.String requestScheduleConfig_scheduleConfig_ScheduleExpression = null;
            if (cmdletContext.ScheduleConfig_ScheduleExpression != null)
            {
                requestScheduleConfig_scheduleConfig_ScheduleExpression = cmdletContext.ScheduleConfig_ScheduleExpression;
            }
            if (requestScheduleConfig_scheduleConfig_ScheduleExpression != null)
            {
                request.ScheduleConfig.ScheduleExpression = requestScheduleConfig_scheduleConfig_ScheduleExpression;
                requestScheduleConfigIsNull = false;
            }
             // determine if request.ScheduleConfig should be set to null
            if (requestScheduleConfigIsNull)
            {
                request.ScheduleConfig = null;
            }
            if (cmdletContext.SourceURI != null)
            {
                request.SourceURI = cmdletContext.SourceURI;
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
        
        private Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.CreateDataIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "CreateDataIntegration");
            try
            {
                #if DESKTOP
                return client.CreateDataIntegration(request);
                #elif CORECLR
                return client.CreateDataIntegrationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKey { get; set; }
            public System.String Name { get; set; }
            public System.String ScheduleConfig_FirstExecutionFrom { get; set; }
            public System.String ScheduleConfig_Object { get; set; }
            public System.String ScheduleConfig_ScheduleExpression { get; set; }
            public System.String SourceURI { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse, NewAISDataIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
