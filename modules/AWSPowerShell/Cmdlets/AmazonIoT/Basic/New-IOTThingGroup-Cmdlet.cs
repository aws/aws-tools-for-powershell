/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Create a thing group.
    /// </summary>
    [Cmdlet("New", "IOTThingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingGroupResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateThingGroup API operation.", Operation = new[] {"CreateThingGroup"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingGroupResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateThingGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTThingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AttributePayload_Attribute
        /// <summary>
        /// <para>
        /// <para>A JSON string containing up to three key-value pair in JSON format. For example:</para><para><code>{\"attributes\":{\"string1\":\"string2\"}}</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ThingGroupProperties_AttributePayload_Attributes")]
        public System.Collections.Hashtable AttributePayload_Attribute { get; set; }
        #endregion
        
        #region Parameter AttributePayload_Merge
        /// <summary>
        /// <para>
        /// <para>Specifies whether the list of attributes provided in the <code>AttributePayload</code>
        /// is merged with the attributes stored in the registry, instead of overwriting them.</para><para>To remove an attribute, call <code>UpdateThing</code> with an empty attribute value.</para><note><para>The <code>merge</code> attribute is only valid when calling <code>UpdateThing</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ThingGroupProperties_AttributePayload_Merge")]
        public System.Boolean AttributePayload_Merge { get; set; }
        #endregion
        
        #region Parameter ParentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parent thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentGroupName { get; set; }
        #endregion
        
        #region Parameter ThingGroupProperties_ThingGroupDescription
        /// <summary>
        /// <para>
        /// <para>The thing group description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
        #endregion
        
        #region Parameter ThingGroupName
        /// <summary>
        /// <para>
        /// <para>The thing group name to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingGroupName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ThingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTThingGroup (CreateThingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ParentGroupName = this.ParentGroupName;
            context.ThingGroupName = this.ThingGroupName;
            if (this.AttributePayload_Attribute != null)
            {
                context.ThingGroupProperties_AttributePayload_Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributePayload_Attribute.Keys)
                {
                    context.ThingGroupProperties_AttributePayload_Attributes.Add((String)hashKey, (String)(this.AttributePayload_Attribute[hashKey]));
                }
            }
            if (ParameterWasBound("AttributePayload_Merge"))
                context.ThingGroupProperties_AttributePayload_Merge = this.AttributePayload_Merge;
            context.ThingGroupProperties_ThingGroupDescription = this.ThingGroupProperties_ThingGroupDescription;
            
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
            var request = new Amazon.IoT.Model.CreateThingGroupRequest();
            
            if (cmdletContext.ParentGroupName != null)
            {
                request.ParentGroupName = cmdletContext.ParentGroupName;
            }
            if (cmdletContext.ThingGroupName != null)
            {
                request.ThingGroupName = cmdletContext.ThingGroupName;
            }
            
             // populate ThingGroupProperties
            bool requestThingGroupPropertiesIsNull = true;
            request.ThingGroupProperties = new Amazon.IoT.Model.ThingGroupProperties();
            System.String requestThingGroupProperties_thingGroupProperties_ThingGroupDescription = null;
            if (cmdletContext.ThingGroupProperties_ThingGroupDescription != null)
            {
                requestThingGroupProperties_thingGroupProperties_ThingGroupDescription = cmdletContext.ThingGroupProperties_ThingGroupDescription;
            }
            if (requestThingGroupProperties_thingGroupProperties_ThingGroupDescription != null)
            {
                request.ThingGroupProperties.ThingGroupDescription = requestThingGroupProperties_thingGroupProperties_ThingGroupDescription;
                requestThingGroupPropertiesIsNull = false;
            }
            Amazon.IoT.Model.AttributePayload requestThingGroupProperties_thingGroupProperties_AttributePayload = null;
            
             // populate AttributePayload
            bool requestThingGroupProperties_thingGroupProperties_AttributePayloadIsNull = true;
            requestThingGroupProperties_thingGroupProperties_AttributePayload = new Amazon.IoT.Model.AttributePayload();
            Dictionary<System.String, System.String> requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Attribute = null;
            if (cmdletContext.ThingGroupProperties_AttributePayload_Attributes != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Attribute = cmdletContext.ThingGroupProperties_AttributePayload_Attributes;
            }
            if (requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Attribute != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload.Attributes = requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Attribute;
                requestThingGroupProperties_thingGroupProperties_AttributePayloadIsNull = false;
            }
            System.Boolean? requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Merge = null;
            if (cmdletContext.ThingGroupProperties_AttributePayload_Merge != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Merge = cmdletContext.ThingGroupProperties_AttributePayload_Merge.Value;
            }
            if (requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Merge != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload.Merge = requestThingGroupProperties_thingGroupProperties_AttributePayload_attributePayload_Merge.Value;
                requestThingGroupProperties_thingGroupProperties_AttributePayloadIsNull = false;
            }
             // determine if requestThingGroupProperties_thingGroupProperties_AttributePayload should be set to null
            if (requestThingGroupProperties_thingGroupProperties_AttributePayloadIsNull)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload = null;
            }
            if (requestThingGroupProperties_thingGroupProperties_AttributePayload != null)
            {
                request.ThingGroupProperties.AttributePayload = requestThingGroupProperties_thingGroupProperties_AttributePayload;
                requestThingGroupPropertiesIsNull = false;
            }
             // determine if request.ThingGroupProperties should be set to null
            if (requestThingGroupPropertiesIsNull)
            {
                request.ThingGroupProperties = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.IoT.Model.CreateThingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateThingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateThingGroup");
            try
            {
                #if DESKTOP
                return client.CreateThingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateThingGroupAsync(request);
                return task.Result;
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
            public System.String ParentGroupName { get; set; }
            public System.String ThingGroupName { get; set; }
            public Dictionary<System.String, System.String> ThingGroupProperties_AttributePayload_Attributes { get; set; }
            public System.Boolean? ThingGroupProperties_AttributePayload_Merge { get; set; }
            public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
        }
        
    }
}
