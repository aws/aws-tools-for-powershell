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
using System.Threading;
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Creates a new component for an Amplify app.
    /// </summary>
    [Cmdlet("New", "AMPUIComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Component")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder CreateComponent API operation.", Operation = new[] {"CreateComponent"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.CreateComponentResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Component or Amazon.AmplifyUIBuilder.Model.CreateComponentResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Component object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.CreateComponentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMPUIComponentCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the Amplify app to associate with the component.</para>
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
        
        #region Parameter ComponentToCreate_BindingProperty
        /// <summary>
        /// <para>
        /// <para>The data binding information for the component's properties.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ComponentToCreate_BindingProperties")]
        public System.Collections.Hashtable ComponentToCreate_BindingProperty { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Child
        /// <summary>
        /// <para>
        /// <para>A list of child components that are instances of the main component.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentToCreate_Children")]
        public Amazon.AmplifyUIBuilder.Model.ComponentChild[] ComponentToCreate_Child { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_CollectionProperty
        /// <summary>
        /// <para>
        /// <para>The data binding configuration for customizing a component's properties. Use this
        /// for a collection component.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentToCreate_CollectionProperties")]
        public System.Collections.Hashtable ComponentToCreate_CollectionProperty { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_ComponentType
        /// <summary>
        /// <para>
        /// <para>The component type. This can be an Amplify custom UI component or another custom component.</para>
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
        public System.String ComponentToCreate_ComponentType { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is a part of the Amplify app.</para>
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
        
        #region Parameter ComponentToCreate_Event
        /// <summary>
        /// <para>
        /// <para>The event configuration for the component. Use for the workflow feature in Amplify
        /// Studio that allows you to bind events and actions to components.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentToCreate_Events")]
        public System.Collections.Hashtable ComponentToCreate_Event { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the component</para>
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
        public System.String ComponentToCreate_Name { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Override
        /// <summary>
        /// <para>
        /// <para>Describes the component properties that can be overriden to customize an instance
        /// of the component.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ComponentToCreate_Overrides")]
        public System.Collections.Hashtable ComponentToCreate_Override { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Property
        /// <summary>
        /// <para>
        /// <para>Describes the component's properties.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ComponentToCreate_Properties")]
        public System.Collections.Hashtable ComponentToCreate_Property { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the component when it was imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentToCreate_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_SourceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the component in its original source system, such as Figma.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentToCreate_SourceId { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Tag
        /// <summary>
        /// <para>
        /// <para>One or more key-value pairs to use when tagging the component data.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentToCreate_Tags")]
        public System.Collections.Hashtable ComponentToCreate_Tag { get; set; }
        #endregion
        
        #region Parameter ComponentToCreate_Variant
        /// <summary>
        /// <para>
        /// <para>A list of the unique variants of this component.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ComponentToCreate_Variants")]
        public Amazon.AmplifyUIBuilder.Model.ComponentVariant[] ComponentToCreate_Variant { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.CreateComponentResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.CreateComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPUIComponent (CreateComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.CreateComponentResponse, NewAMPUIComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.ComponentToCreate_BindingProperty != null)
            {
                context.ComponentToCreate_BindingProperty = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_BindingProperty.Keys)
                {
                    context.ComponentToCreate_BindingProperty.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue)(this.ComponentToCreate_BindingProperty[hashKey]));
                }
            }
            #if MODULAR
            if (this.ComponentToCreate_BindingProperty == null && ParameterWasBound(nameof(this.ComponentToCreate_BindingProperty)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_BindingProperty which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentToCreate_Child != null)
            {
                context.ComponentToCreate_Child = new List<Amazon.AmplifyUIBuilder.Model.ComponentChild>(this.ComponentToCreate_Child);
            }
            if (this.ComponentToCreate_CollectionProperty != null)
            {
                context.ComponentToCreate_CollectionProperty = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_CollectionProperty.Keys)
                {
                    context.ComponentToCreate_CollectionProperty.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration)(this.ComponentToCreate_CollectionProperty[hashKey]));
                }
            }
            context.ComponentToCreate_ComponentType = this.ComponentToCreate_ComponentType;
            #if MODULAR
            if (this.ComponentToCreate_ComponentType == null && ParameterWasBound(nameof(this.ComponentToCreate_ComponentType)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_ComponentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentToCreate_Event != null)
            {
                context.ComponentToCreate_Event = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_Event.Keys)
                {
                    context.ComponentToCreate_Event.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentEvent)(this.ComponentToCreate_Event[hashKey]));
                }
            }
            context.ComponentToCreate_Name = this.ComponentToCreate_Name;
            #if MODULAR
            if (this.ComponentToCreate_Name == null && ParameterWasBound(nameof(this.ComponentToCreate_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentToCreate_Override != null)
            {
                context.ComponentToCreate_Override = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_Override.Keys)
                {
                    context.ComponentToCreate_Override.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.ComponentToCreate_Override[hashKey]));
                }
            }
            #if MODULAR
            if (this.ComponentToCreate_Override == null && ParameterWasBound(nameof(this.ComponentToCreate_Override)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_Override which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentToCreate_Property != null)
            {
                context.ComponentToCreate_Property = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_Property.Keys)
                {
                    context.ComponentToCreate_Property.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.ComponentProperty)(this.ComponentToCreate_Property[hashKey]));
                }
            }
            #if MODULAR
            if (this.ComponentToCreate_Property == null && ParameterWasBound(nameof(this.ComponentToCreate_Property)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_Property which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComponentToCreate_SchemaVersion = this.ComponentToCreate_SchemaVersion;
            context.ComponentToCreate_SourceId = this.ComponentToCreate_SourceId;
            if (this.ComponentToCreate_Tag != null)
            {
                context.ComponentToCreate_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComponentToCreate_Tag.Keys)
                {
                    context.ComponentToCreate_Tag.Add((String)hashKey, (System.String)(this.ComponentToCreate_Tag[hashKey]));
                }
            }
            if (this.ComponentToCreate_Variant != null)
            {
                context.ComponentToCreate_Variant = new List<Amazon.AmplifyUIBuilder.Model.ComponentVariant>(this.ComponentToCreate_Variant);
            }
            #if MODULAR
            if (this.ComponentToCreate_Variant == null && ParameterWasBound(nameof(this.ComponentToCreate_Variant)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentToCreate_Variant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.CreateComponentRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ComponentToCreate
            var requestComponentToCreateIsNull = true;
            request.ComponentToCreate = new Amazon.AmplifyUIBuilder.Model.CreateComponentData();
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue> requestComponentToCreate_componentToCreate_BindingProperty = null;
            if (cmdletContext.ComponentToCreate_BindingProperty != null)
            {
                requestComponentToCreate_componentToCreate_BindingProperty = cmdletContext.ComponentToCreate_BindingProperty;
            }
            if (requestComponentToCreate_componentToCreate_BindingProperty != null)
            {
                request.ComponentToCreate.BindingProperties = requestComponentToCreate_componentToCreate_BindingProperty;
                requestComponentToCreateIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ComponentChild> requestComponentToCreate_componentToCreate_Child = null;
            if (cmdletContext.ComponentToCreate_Child != null)
            {
                requestComponentToCreate_componentToCreate_Child = cmdletContext.ComponentToCreate_Child;
            }
            if (requestComponentToCreate_componentToCreate_Child != null)
            {
                request.ComponentToCreate.Children = requestComponentToCreate_componentToCreate_Child;
                requestComponentToCreateIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration> requestComponentToCreate_componentToCreate_CollectionProperty = null;
            if (cmdletContext.ComponentToCreate_CollectionProperty != null)
            {
                requestComponentToCreate_componentToCreate_CollectionProperty = cmdletContext.ComponentToCreate_CollectionProperty;
            }
            if (requestComponentToCreate_componentToCreate_CollectionProperty != null)
            {
                request.ComponentToCreate.CollectionProperties = requestComponentToCreate_componentToCreate_CollectionProperty;
                requestComponentToCreateIsNull = false;
            }
            System.String requestComponentToCreate_componentToCreate_ComponentType = null;
            if (cmdletContext.ComponentToCreate_ComponentType != null)
            {
                requestComponentToCreate_componentToCreate_ComponentType = cmdletContext.ComponentToCreate_ComponentType;
            }
            if (requestComponentToCreate_componentToCreate_ComponentType != null)
            {
                request.ComponentToCreate.ComponentType = requestComponentToCreate_componentToCreate_ComponentType;
                requestComponentToCreateIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent> requestComponentToCreate_componentToCreate_Event = null;
            if (cmdletContext.ComponentToCreate_Event != null)
            {
                requestComponentToCreate_componentToCreate_Event = cmdletContext.ComponentToCreate_Event;
            }
            if (requestComponentToCreate_componentToCreate_Event != null)
            {
                request.ComponentToCreate.Events = requestComponentToCreate_componentToCreate_Event;
                requestComponentToCreateIsNull = false;
            }
            System.String requestComponentToCreate_componentToCreate_Name = null;
            if (cmdletContext.ComponentToCreate_Name != null)
            {
                requestComponentToCreate_componentToCreate_Name = cmdletContext.ComponentToCreate_Name;
            }
            if (requestComponentToCreate_componentToCreate_Name != null)
            {
                request.ComponentToCreate.Name = requestComponentToCreate_componentToCreate_Name;
                requestComponentToCreateIsNull = false;
            }
            Dictionary<System.String, Dictionary<System.String, System.String>> requestComponentToCreate_componentToCreate_Override = null;
            if (cmdletContext.ComponentToCreate_Override != null)
            {
                requestComponentToCreate_componentToCreate_Override = cmdletContext.ComponentToCreate_Override;
            }
            if (requestComponentToCreate_componentToCreate_Override != null)
            {
                request.ComponentToCreate.Overrides = requestComponentToCreate_componentToCreate_Override;
                requestComponentToCreateIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty> requestComponentToCreate_componentToCreate_Property = null;
            if (cmdletContext.ComponentToCreate_Property != null)
            {
                requestComponentToCreate_componentToCreate_Property = cmdletContext.ComponentToCreate_Property;
            }
            if (requestComponentToCreate_componentToCreate_Property != null)
            {
                request.ComponentToCreate.Properties = requestComponentToCreate_componentToCreate_Property;
                requestComponentToCreateIsNull = false;
            }
            System.String requestComponentToCreate_componentToCreate_SchemaVersion = null;
            if (cmdletContext.ComponentToCreate_SchemaVersion != null)
            {
                requestComponentToCreate_componentToCreate_SchemaVersion = cmdletContext.ComponentToCreate_SchemaVersion;
            }
            if (requestComponentToCreate_componentToCreate_SchemaVersion != null)
            {
                request.ComponentToCreate.SchemaVersion = requestComponentToCreate_componentToCreate_SchemaVersion;
                requestComponentToCreateIsNull = false;
            }
            System.String requestComponentToCreate_componentToCreate_SourceId = null;
            if (cmdletContext.ComponentToCreate_SourceId != null)
            {
                requestComponentToCreate_componentToCreate_SourceId = cmdletContext.ComponentToCreate_SourceId;
            }
            if (requestComponentToCreate_componentToCreate_SourceId != null)
            {
                request.ComponentToCreate.SourceId = requestComponentToCreate_componentToCreate_SourceId;
                requestComponentToCreateIsNull = false;
            }
            Dictionary<System.String, System.String> requestComponentToCreate_componentToCreate_Tag = null;
            if (cmdletContext.ComponentToCreate_Tag != null)
            {
                requestComponentToCreate_componentToCreate_Tag = cmdletContext.ComponentToCreate_Tag;
            }
            if (requestComponentToCreate_componentToCreate_Tag != null)
            {
                request.ComponentToCreate.Tags = requestComponentToCreate_componentToCreate_Tag;
                requestComponentToCreateIsNull = false;
            }
            List<Amazon.AmplifyUIBuilder.Model.ComponentVariant> requestComponentToCreate_componentToCreate_Variant = null;
            if (cmdletContext.ComponentToCreate_Variant != null)
            {
                requestComponentToCreate_componentToCreate_Variant = cmdletContext.ComponentToCreate_Variant;
            }
            if (requestComponentToCreate_componentToCreate_Variant != null)
            {
                request.ComponentToCreate.Variants = requestComponentToCreate_componentToCreate_Variant;
                requestComponentToCreateIsNull = false;
            }
             // determine if request.ComponentToCreate should be set to null
            if (requestComponentToCreateIsNull)
            {
                request.ComponentToCreate = null;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
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
        
        private Amazon.AmplifyUIBuilder.Model.CreateComponentResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.CreateComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "CreateComponent");
            try
            {
                return client.CreateComponentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentBindingPropertiesValue> ComponentToCreate_BindingProperty { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ComponentChild> ComponentToCreate_Child { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentDataConfiguration> ComponentToCreate_CollectionProperty { get; set; }
            public System.String ComponentToCreate_ComponentType { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentEvent> ComponentToCreate_Event { get; set; }
            public System.String ComponentToCreate_Name { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> ComponentToCreate_Override { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.ComponentProperty> ComponentToCreate_Property { get; set; }
            public System.String ComponentToCreate_SchemaVersion { get; set; }
            public System.String ComponentToCreate_SourceId { get; set; }
            public Dictionary<System.String, System.String> ComponentToCreate_Tag { get; set; }
            public List<Amazon.AmplifyUIBuilder.Model.ComponentVariant> ComponentToCreate_Variant { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.CreateComponentResponse, NewAMPUIComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
