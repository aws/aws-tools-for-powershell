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
using Amazon.AppRegistry;
using Amazon.AppRegistry.Model;

namespace Amazon.PowerShell.Cmdlets.SCAR
{
    /// <summary>
    /// Updates an existing attribute group with new details.
    /// </summary>
    [Cmdlet("Update", "SCARAttributeGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRegistry.Model.AttributeGroup")]
    [AWSCmdlet("Calls the AWS Service Catalog App Registry UpdateAttributeGroup API operation.", Operation = new[] {"UpdateAttributeGroup"}, SelectReturnType = typeof(Amazon.AppRegistry.Model.UpdateAttributeGroupResponse))]
    [AWSCmdletOutput("Amazon.AppRegistry.Model.AttributeGroup or Amazon.AppRegistry.Model.UpdateAttributeGroupResponse",
        "This cmdlet returns an Amazon.AppRegistry.Model.AttributeGroup object.",
        "The service call response (type Amazon.AppRegistry.Model.UpdateAttributeGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSCARAttributeGroupCmdlet : AmazonAppRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeGroup
        /// <summary>
        /// <para>
        /// <para> The name, ID, or ARN of the attribute group that holds the attributes to describe
        /// the application. </para>
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
        public System.String AttributeGroup { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A JSON string in the form of nested key-value pairs that represent the attributes
        /// in the group and describes an application and its components.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.String Attribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the attribute group that the user provides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Deprecated: The new name of the attribute group. The name must be unique in the region
        /// in which you are updating the attribute group. Please do not use this field as we
        /// have stopped supporting name updates.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Name update for attribute group is deprecated.")]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttributeGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRegistry.Model.UpdateAttributeGroupResponse).
        /// Specifying the name of a property of type Amazon.AppRegistry.Model.UpdateAttributeGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttributeGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AttributeGroup parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AttributeGroup' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AttributeGroup' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCARAttributeGroup (UpdateAttributeGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRegistry.Model.UpdateAttributeGroupResponse, UpdateSCARAttributeGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AttributeGroup;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttributeGroup = this.AttributeGroup;
            #if MODULAR
            if (this.AttributeGroup == null && ParameterWasBound(nameof(this.AttributeGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Attribute = this.Attribute;
            context.Description = this.Description;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
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
            var request = new Amazon.AppRegistry.Model.UpdateAttributeGroupRequest();
            
            if (cmdletContext.AttributeGroup != null)
            {
                request.AttributeGroup = cmdletContext.AttributeGroup;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.AppRegistry.Model.UpdateAttributeGroupResponse CallAWSServiceOperation(IAmazonAppRegistry client, Amazon.AppRegistry.Model.UpdateAttributeGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog App Registry", "UpdateAttributeGroup");
            try
            {
                #if DESKTOP
                return client.UpdateAttributeGroup(request);
                #elif CORECLR
                return client.UpdateAttributeGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AttributeGroup { get; set; }
            public System.String Attribute { get; set; }
            public System.String Description { get; set; }
            [System.ObsoleteAttribute]
            public System.String Name { get; set; }
            public System.Func<Amazon.AppRegistry.Model.UpdateAttributeGroupResponse, UpdateSCARAttributeGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttributeGroup;
        }
        
    }
}
