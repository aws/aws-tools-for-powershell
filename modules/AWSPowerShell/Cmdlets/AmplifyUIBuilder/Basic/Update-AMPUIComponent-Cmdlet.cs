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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Updates an existing component.
    /// </summary>
    [Cmdlet("Update", "AMPUIComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Component")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder UpdateComponent API operation.", Operation = new[] {"UpdateComponent"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Component or Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Component object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAMPUIComponentCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for the Amplify app.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_BindingProperty
        /// <summary>
        /// <para>
        /// <para>The data binding information for the component's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_BindingProperties")]
        public System.Collections.Hashtable UpdatedComponent_BindingProperty { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Child
        /// <summary>
        /// <para>
        /// <para>The components that are instances of the main component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_Children")]
        public Amazon.AmplifyUIBuilder.Model.ComponentChild[] UpdatedComponent_Child { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_CollectionProperty
        /// <summary>
        /// <para>
        /// <para>The configuration for binding a component's properties to a data model. Use this for
        /// a collection component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_CollectionProperties")]
        public System.Collections.Hashtable UpdatedComponent_CollectionProperty { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_ComponentType
        /// <summary>
        /// <para>
        /// <para>The type of the component. This can be an Amplify custom UI component or another custom
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedComponent_ComponentType { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is part of the Amplify app.</para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Event
        /// <summary>
        /// <para>
        /// <para>The event configuration for the component. Use for the workflow feature in Amplify
        /// Studio that allows you to bind events and actions to components.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_Events")]
        public System.Collections.Hashtable UpdatedComponent_Event { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique ID for the component.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Id
        /// <summary>
        /// <para>
        /// <para>The unique ID of the component to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedComponent_Id { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the component to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedComponent_Name { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Override
        /// <summary>
        /// <para>
        /// <para>Describes the properties that can be overriden to customize the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_Overrides")]
        public System.Collections.Hashtable UpdatedComponent_Override { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Property
        /// <summary>
        /// <para>
        /// <para>Describes the component's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_Properties")]
        public System.Collections.Hashtable UpdatedComponent_Property { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the component when it was imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedComponent_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_SourceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the component in its original source system, such as Figma.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedComponent_SourceId { get; set; }
        #endregion
        
        #region Parameter UpdatedComponent_Variant
        /// <summary>
        /// <para>
        /// <para>A list of the unique variants of the main component being updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedComponent_Variants")]
        public Amazon.AmplifyUIBuilder.Model.ComponentVariant[] UpdatedComponent_Variant { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPUIComponent (UpdateComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse, UpdateAMPUIComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpdatedComponent_BindingProperty != null)
            {
                context.UpdatedComponent_BindingProperty = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedComponent_BindingProperty.Keys)
                {
                    context.UpdatedComponent_BindingProperty.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue)(this.UpdatedComponent_BindingProperty[hashKey]));
                }
            }
            if (this.UpdatedComponent_Child != null)
            {
                context.UpdatedComponent_Child = new List<Amazon.AmplifyUIBuilder.Model.ComponentChild>(this.UpdatedComponent_Child);
            }
            if (this.UpdatedComponent_CollectionProperty != null)
            {
                context.UpdatedComponent_CollectionProperty = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedComponent_CollectionProperty.Keys)
                {
                    context.UpdatedComponent_CollectionProperty.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration)(this.UpdatedComponent_CollectionProperty[hashKey]));
                }
            }
            context.UpdatedComponent_ComponentType = this.UpdatedComponent_ComponentType;
            if (this.UpdatedComponent_Event != null)
            {
                context.UpdatedComponent_Event = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedComponent_Event.Keys)
                {
                    context.UpdatedComponent_Event.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentEvent)(this.UpdatedComponent_Event[hashKey]));
                }
            }
            context.UpdatedComponent_Id = this.UpdatedComponent_Id;
            context.UpdatedComponent_Name = this.UpdatedComponent_Name;
            if (this.UpdatedComponent_Override != null)
            {
                context.UpdatedComponent_Override = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedComponent_Override.Keys)
                {
                    context.UpdatedComponent_Override.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.UpdatedComponent_Override[hashKey]));
                }
            }
            if (this.UpdatedComponent_Property != null)
            {
                context.UpdatedComponent_Property = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedComponent_Property.Keys)
                {
                    context.UpdatedComponent_Property.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentProperty)(this.UpdatedComponent_Property[hashKey]));
                }
            }
            context.UpdatedComponent_SchemaVersion = this.UpdatedComponent_SchemaVersion;
            context.UpdatedComponent_SourceId = this.UpdatedComponent_SourceId;
            if (this.UpdatedComponent_Variant != null)
            {
                context.UpdatedComponent_Variant = new List<Amazon.AmplifyUIBuilder.Model.ComponentVariant>(this.UpdatedComponent_Variant);
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
            var request = new Amazon.AmplifyUIBuilder.Model.UpdateComponentRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate UpdatedComponent
            var requestUpdatedComponentIsNull = true;
            request.UpdatedComponent = new Amazon.AmplifyUIBuilder.Model.UpdateComponentData();
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue> requestUpdatedComponent_updatedComponent_BindingProperty = null;
            if (cmdletContext.UpdatedComponent_BindingProperty != null)
            {
                requestUpdatedComponent_updatedComponent_BindingProperty = cmdletContext.UpdatedComponent_BindingProperty;
            }
            if (requestUpdatedComponent_updatedComponent_BindingProperty != null)
            {
                request.UpdatedComponent.BindingProperties = requestUpdatedComponent_updatedComponent_BindingProperty;
                requestUpdatedComponentIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ComponentChild> requestUpdatedComponent_updatedComponent_Child = null;
            if (cmdletContext.UpdatedComponent_Child != null)
            {
                requestUpdatedComponent_updatedComponent_Child = cmdletContext.UpdatedComponent_Child;
            }
            if (requestUpdatedComponent_updatedComponent_Child != null)
            {
                request.UpdatedComponent.Children = requestUpdatedComponent_updatedComponent_Child;
                requestUpdatedComponentIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration> requestUpdatedComponent_updatedComponent_CollectionProperty = null;
            if (cmdletContext.UpdatedComponent_CollectionProperty != null)
            {
                requestUpdatedComponent_updatedComponent_CollectionProperty = cmdletContext.UpdatedComponent_CollectionProperty;
            }
            if (requestUpdatedComponent_updatedComponent_CollectionProperty != null)
            {
                request.UpdatedComponent.CollectionProperties = requestUpdatedComponent_updatedComponent_CollectionProperty;
                requestUpdatedComponentIsNull = false;
            }
            System.String requestUpdatedComponent_updatedComponent_ComponentType = null;
            if (cmdletContext.UpdatedComponent_ComponentType != null)
            {
                requestUpdatedComponent_updatedComponent_ComponentType = cmdletContext.UpdatedComponent_ComponentType;
            }
            if (requestUpdatedComponent_updatedComponent_ComponentType != null)
            {
                request.UpdatedComponent.ComponentType = requestUpdatedComponent_updatedComponent_ComponentType;
                requestUpdatedComponentIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent> requestUpdatedComponent_updatedComponent_Event = null;
            if (cmdletContext.UpdatedComponent_Event != null)
            {
                requestUpdatedComponent_updatedComponent_Event = cmdletContext.UpdatedComponent_Event;
            }
            if (requestUpdatedComponent_updatedComponent_Event != null)
            {
                request.UpdatedComponent.Events = requestUpdatedComponent_updatedComponent_Event;
                requestUpdatedComponentIsNull = false;
            }
            System.String requestUpdatedComponent_updatedComponent_Id = null;
            if (cmdletContext.UpdatedComponent_Id != null)
            {
                requestUpdatedComponent_updatedComponent_Id = cmdletContext.UpdatedComponent_Id;
            }
            if (requestUpdatedComponent_updatedComponent_Id != null)
            {
                request.UpdatedComponent.Id = requestUpdatedComponent_updatedComponent_Id;
                requestUpdatedComponentIsNull = false;
            }
            System.String requestUpdatedComponent_updatedComponent_Name = null;
            if (cmdletContext.UpdatedComponent_Name != null)
            {
                requestUpdatedComponent_updatedComponent_Name = cmdletContext.UpdatedComponent_Name;
            }
            if (requestUpdatedComponent_updatedComponent_Name != null)
            {
                request.UpdatedComponent.Name = requestUpdatedComponent_updatedComponent_Name;
                requestUpdatedComponentIsNull = false;
            }
            Dictionary<System.String, Dictionary<System.String, System.String>> requestUpdatedComponent_updatedComponent_Override = null;
            if (cmdletContext.UpdatedComponent_Override != null)
            {
                requestUpdatedComponent_updatedComponent_Override = cmdletContext.UpdatedComponent_Override;
            }
            if (requestUpdatedComponent_updatedComponent_Override != null)
            {
                request.UpdatedComponent.Overrides = requestUpdatedComponent_updatedComponent_Override;
                requestUpdatedComponentIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty> requestUpdatedComponent_updatedComponent_Property = null;
            if (cmdletContext.UpdatedComponent_Property != null)
            {
                requestUpdatedComponent_updatedComponent_Property = cmdletContext.UpdatedComponent_Property;
            }
            if (requestUpdatedComponent_updatedComponent_Property != null)
            {
                request.UpdatedComponent.Properties = requestUpdatedComponent_updatedComponent_Property;
                requestUpdatedComponentIsNull = false;
            }
            System.String requestUpdatedComponent_updatedComponent_SchemaVersion = null;
            if (cmdletContext.UpdatedComponent_SchemaVersion != null)
            {
                requestUpdatedComponent_updatedComponent_SchemaVersion = cmdletContext.UpdatedComponent_SchemaVersion;
            }
            if (requestUpdatedComponent_updatedComponent_SchemaVersion != null)
            {
                request.UpdatedComponent.SchemaVersion = requestUpdatedComponent_updatedComponent_SchemaVersion;
                requestUpdatedComponentIsNull = false;
            }
            System.String requestUpdatedComponent_updatedComponent_SourceId = null;
            if (cmdletContext.UpdatedComponent_SourceId != null)
            {
                requestUpdatedComponent_updatedComponent_SourceId = cmdletContext.UpdatedComponent_SourceId;
            }
            if (requestUpdatedComponent_updatedComponent_SourceId != null)
            {
                request.UpdatedComponent.SourceId = requestUpdatedComponent_updatedComponent_SourceId;
                requestUpdatedComponentIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ComponentVariant> requestUpdatedComponent_updatedComponent_Variant = null;
            if (cmdletContext.UpdatedComponent_Variant != null)
            {
                requestUpdatedComponent_updatedComponent_Variant = cmdletContext.UpdatedComponent_Variant;
            }
            if (requestUpdatedComponent_updatedComponent_Variant != null)
            {
                request.UpdatedComponent.Variants = requestUpdatedComponent_updatedComponent_Variant;
                requestUpdatedComponentIsNull = false;
            }
             // determine if request.UpdatedComponent should be set to null
            if (requestUpdatedComponentIsNull)
            {
                request.UpdatedComponent = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.UpdateComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "UpdateComponent");
            try
            {
                #if DESKTOP
                return client.UpdateComponent(request);
                #elif CORECLR
                return client.UpdateComponentAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String Id { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue> UpdatedComponent_BindingProperty { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ComponentChild> UpdatedComponent_Child { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration> UpdatedComponent_CollectionProperty { get; set; }
            public System.String UpdatedComponent_ComponentType { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent> UpdatedComponent_Event { get; set; }
            public System.String UpdatedComponent_Id { get; set; }
            public System.String UpdatedComponent_Name { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> UpdatedComponent_Override { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty> UpdatedComponent_Property { get; set; }
            public System.String UpdatedComponent_SchemaVersion { get; set; }
            public System.String UpdatedComponent_SourceId { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ComponentVariant> UpdatedComponent_Variant { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.UpdateComponentResponse, UpdateAMPUIComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
