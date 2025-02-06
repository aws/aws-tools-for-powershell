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
    /// Creates and persists a DataIntegration resource.
    /// 
    ///  <note><para>
    /// You cannot create a DataIntegration association for a DataIntegration that has been
    /// previously associated. Use a different DataIntegration, or recreate the DataIntegration
    /// using the <c>CreateDataIntegration</c> API.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AISDataIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service CreateDataIntegration API operation.", Operation = new[] {"CreateDataIntegration"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAISDataIntegrationCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the DataIntegration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FileConfiguration_Filter
        /// <summary>
        /// <para>
        /// <para>Restrictions for what files should be pulled from the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileConfiguration_Filters")]
        public System.Collections.Hashtable FileConfiguration_Filter { get; set; }
        #endregion
        
        #region Parameter ScheduleConfig_FirstExecutionFrom
        /// <summary>
        /// <para>
        /// <para>The start date for objects to import in the first flow run as an Unix/epoch timestamp
        /// in milliseconds or in ISO-8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleConfig_FirstExecutionFrom { get; set; }
        #endregion
        
        #region Parameter FileConfiguration_Folder
        /// <summary>
        /// <para>
        /// <para>Identifiers for the source folders to pull all files from recursively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileConfiguration_Folders")]
        public System.String[] FileConfiguration_Folder { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN for the DataIntegration.</para>
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
        
        #region Parameter ObjectConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for what data should be pulled from the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ObjectConfiguration { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse).
        /// Specifying the name of a property of type Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.CreateDataIntegrationResponse, NewAISDataIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.FileConfiguration_Filter != null)
            {
                context.FileConfiguration_Filter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.FileConfiguration_Filter.Keys)
                {
                    object hashValue = this.FileConfiguration_Filter[hashKey];
                    if (hashValue == null)
                    {
                        context.FileConfiguration_Filter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.FileConfiguration_Filter.Add((String)hashKey, valueSet);
                }
            }
            if (this.FileConfiguration_Folder != null)
            {
                context.FileConfiguration_Folder = new List<System.String>(this.FileConfiguration_Folder);
            }
            context.KmsKey = this.KmsKey;
            #if MODULAR
            if (this.KmsKey == null && ParameterWasBound(nameof(this.KmsKey)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ObjectConfiguration != null)
            {
                context.ObjectConfiguration = new Dictionary<System.String, Dictionary<System.String, List<System.String>>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ObjectConfiguration.Keys)
                {
                    context.ObjectConfiguration.Add((String)hashKey, (Dictionary<System.String,List<System.String>>)(this.ObjectConfiguration[hashKey]));
                }
            }
            context.ScheduleConfig_FirstExecutionFrom = this.ScheduleConfig_FirstExecutionFrom;
            context.ScheduleConfig_Object = this.ScheduleConfig_Object;
            context.ScheduleConfig_ScheduleExpression = this.ScheduleConfig_ScheduleExpression;
            context.SourceURI = this.SourceURI;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            
             // populate FileConfiguration
            var requestFileConfigurationIsNull = true;
            request.FileConfiguration = new Amazon.AppIntegrationsService.Model.FileConfiguration();
            Dictionary<System.String, List<System.String>> requestFileConfiguration_fileConfiguration_Filter = null;
            if (cmdletContext.FileConfiguration_Filter != null)
            {
                requestFileConfiguration_fileConfiguration_Filter = cmdletContext.FileConfiguration_Filter;
            }
            if (requestFileConfiguration_fileConfiguration_Filter != null)
            {
                request.FileConfiguration.Filters = requestFileConfiguration_fileConfiguration_Filter;
                requestFileConfigurationIsNull = false;
            }
            List<System.String> requestFileConfiguration_fileConfiguration_Folder = null;
            if (cmdletContext.FileConfiguration_Folder != null)
            {
                requestFileConfiguration_fileConfiguration_Folder = cmdletContext.FileConfiguration_Folder;
            }
            if (requestFileConfiguration_fileConfiguration_Folder != null)
            {
                request.FileConfiguration.Folders = requestFileConfiguration_fileConfiguration_Folder;
                requestFileConfigurationIsNull = false;
            }
             // determine if request.FileConfiguration should be set to null
            if (requestFileConfigurationIsNull)
            {
                request.FileConfiguration = null;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ObjectConfiguration != null)
            {
                request.ObjectConfiguration = cmdletContext.ObjectConfiguration;
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
            public Dictionary<System.String, List<System.String>> FileConfiguration_Filter { get; set; }
            public List<System.String> FileConfiguration_Folder { get; set; }
            public System.String KmsKey { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Dictionary<System.String, List<System.String>>> ObjectConfiguration { get; set; }
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
