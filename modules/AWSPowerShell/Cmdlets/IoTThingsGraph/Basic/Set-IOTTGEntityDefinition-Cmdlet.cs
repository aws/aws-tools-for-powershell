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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Asynchronously uploads one or more entity definitions to the user's namespace. The
    /// <code>document</code> parameter is required if <code>syncWithPublicNamespace</code>
    /// and <code>deleteExistingEntites</code> are false. If the <code>syncWithPublicNamespace</code>
    /// parameter is set to <code>true</code>, the user's namespace will synchronize with
    /// the latest version of the public namespace. If <code>deprecateExistingEntities</code>
    /// is set to true, all entities in the latest version will be deleted before the new
    /// <code>DefinitionDocument</code> is uploaded.
    /// 
    ///  
    /// <para>
    /// When a user uploads entity definitions for the first time, the service creates a new
    /// namespace for the user. The new namespace tracks the public namespace. Currently users
    /// can have only one namespace. The namespace version increments whenever a user uploads
    /// entity definitions that are backwards-incompatible and whenever a user sets the <code>syncWithPublicNamespace</code>
    /// parameter or the <code>deprecateExistingEntities</code> parameter to <code>true</code>.
    /// </para><para>
    /// The IDs for all of the entities should be in URN format. Each entity must be in the
    /// user's namespace. Users can't create entities in the public namespace, but entity
    /// definitions can refer to entities in the public namespace.
    /// </para><para>
    /// Valid entities are <code>Device</code>, <code>DeviceModel</code>, <code>Service</code>,
    /// <code>Capability</code>, <code>State</code>, <code>Action</code>, <code>Event</code>,
    /// <code>Property</code>, <code>Mapping</code>, <code>Enum</code>. 
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Set", "IOTTGEntityDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Things Graph UploadEntityDefinitions API operation.", Operation = new[] {"UploadEntityDefinitions"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class SetIOTTGEntityDefinitionCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeprecateExistingEntity
        /// <summary>
        /// <para>
        /// <para>A Boolean that specifies whether to deprecate all entities in the latest version before
        /// uploading the new <code>DefinitionDocument</code>. If set to <code>true</code>, the
        /// upload will create a new namespace version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeprecateExistingEntities")]
        public System.Boolean? DeprecateExistingEntity { get; set; }
        #endregion
        
        #region Parameter Document_Language
        /// <summary>
        /// <para>
        /// <para>The language used to define the entity. <code>GRAPHQL</code> is the only valid value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTThingsGraph.DefinitionLanguage")]
        public Amazon.IoTThingsGraph.DefinitionLanguage Document_Language { get; set; }
        #endregion
        
        #region Parameter SyncWithPublicNamespace
        /// <summary>
        /// <para>
        /// <para>A Boolean that specifies whether to synchronize with the latest version of the public
        /// namespace. If set to <code>true</code>, the upload will create a new namespace version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SyncWithPublicNamespace { get; set; }
        #endregion
        
        #region Parameter Document_Text
        /// <summary>
        /// <para>
        /// <para>The GraphQL text that defines the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Document_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UploadId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UploadId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Document_Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Document_Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Document_Text' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTTGEntityDefinition (UploadEntityDefinitions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse, SetIOTTGEntityDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Document_Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeprecateExistingEntity = this.DeprecateExistingEntity;
            context.Document_Language = this.Document_Language;
            context.Document_Text = this.Document_Text;
            context.SyncWithPublicNamespace = this.SyncWithPublicNamespace;
            
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
            var request = new Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsRequest();
            
            if (cmdletContext.DeprecateExistingEntity != null)
            {
                request.DeprecateExistingEntities = cmdletContext.DeprecateExistingEntity.Value;
            }
            
             // populate Document
            var requestDocumentIsNull = true;
            request.Document = new Amazon.IoTThingsGraph.Model.DefinitionDocument();
            Amazon.IoTThingsGraph.DefinitionLanguage requestDocument_document_Language = null;
            if (cmdletContext.Document_Language != null)
            {
                requestDocument_document_Language = cmdletContext.Document_Language;
            }
            if (requestDocument_document_Language != null)
            {
                request.Document.Language = requestDocument_document_Language;
                requestDocumentIsNull = false;
            }
            System.String requestDocument_document_Text = null;
            if (cmdletContext.Document_Text != null)
            {
                requestDocument_document_Text = cmdletContext.Document_Text;
            }
            if (requestDocument_document_Text != null)
            {
                request.Document.Text = requestDocument_document_Text;
                requestDocumentIsNull = false;
            }
             // determine if request.Document should be set to null
            if (requestDocumentIsNull)
            {
                request.Document = null;
            }
            if (cmdletContext.SyncWithPublicNamespace != null)
            {
                request.SyncWithPublicNamespace = cmdletContext.SyncWithPublicNamespace.Value;
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
        
        private Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "UploadEntityDefinitions");
            try
            {
                #if DESKTOP
                return client.UploadEntityDefinitions(request);
                #elif CORECLR
                return client.UploadEntityDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeprecateExistingEntity { get; set; }
            public Amazon.IoTThingsGraph.DefinitionLanguage Document_Language { get; set; }
            public System.String Document_Text { get; set; }
            public System.Boolean? SyncWithPublicNamespace { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.UploadEntityDefinitionsResponse, SetIOTTGEntityDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UploadId;
        }
        
    }
}
