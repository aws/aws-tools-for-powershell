/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates the data for a thing.
    /// </summary>
    [Cmdlet("Update", "IOTThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateThing operation against AWS IoT.", Operation = new[] {"UpdateThing"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ThingName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.UpdateThingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTThingCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AttributePayload_Attribute
        /// <summary>
        /// <para>
        /// <para>A JSON string containing up to three key-value pair in JSON format. For example:</para><para><code>{\"attributes\":{\"string1\":\"string2\"}})</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AttributePayload_Attributes")]
        public System.Collections.Hashtable AttributePayload_Attribute { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the thing record in the registry. If the version of the record
        /// in the registry does not match the expected version specified in the request, the
        /// <code>UpdateThing</code> request is rejected with a <code>VersionConflictException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter AttributePayload_Merge
        /// <summary>
        /// <para>
        /// <para>Specifies whether the list of attributes provided in the <code>AttributePayload</code>
        /// is merged with the attributes stored in the registry, instead of overwriting them.</para><para>To remove an attribute, call <code>UpdateThing</code> with an empty attribute value.</para><note><para>The <code>merge</code> attribute is only valid when calling <code>UpdateThing</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AttributePayload_Merge { get; set; }
        #endregion
        
        #region Parameter RemoveThingType
        /// <summary>
        /// <para>
        /// <para>Remove a thing type association. If <b>true</b>, the assocation is removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RemoveThingType { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the thing to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter ThingTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the thing type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThingTypeName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ThingName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ThingName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTThing (UpdateThing)"))
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
            
            if (this.AttributePayload_Attribute != null)
            {
                context.AttributePayload_Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributePayload_Attribute.Keys)
                {
                    context.AttributePayload_Attributes.Add((String)hashKey, (String)(this.AttributePayload_Attribute[hashKey]));
                }
            }
            if (ParameterWasBound("AttributePayload_Merge"))
                context.AttributePayload_Merge = this.AttributePayload_Merge;
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            if (ParameterWasBound("RemoveThingType"))
                context.RemoveThingType = this.RemoveThingType;
            context.ThingName = this.ThingName;
            context.ThingTypeName = this.ThingTypeName;
            
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
            var request = new Amazon.IoT.Model.UpdateThingRequest();
            
            
             // populate AttributePayload
            bool requestAttributePayloadIsNull = true;
            request.AttributePayload = new Amazon.IoT.Model.AttributePayload();
            Dictionary<System.String, System.String> requestAttributePayload_attributePayload_Attribute = null;
            if (cmdletContext.AttributePayload_Attributes != null)
            {
                requestAttributePayload_attributePayload_Attribute = cmdletContext.AttributePayload_Attributes;
            }
            if (requestAttributePayload_attributePayload_Attribute != null)
            {
                request.AttributePayload.Attributes = requestAttributePayload_attributePayload_Attribute;
                requestAttributePayloadIsNull = false;
            }
            System.Boolean? requestAttributePayload_attributePayload_Merge = null;
            if (cmdletContext.AttributePayload_Merge != null)
            {
                requestAttributePayload_attributePayload_Merge = cmdletContext.AttributePayload_Merge.Value;
            }
            if (requestAttributePayload_attributePayload_Merge != null)
            {
                request.AttributePayload.Merge = requestAttributePayload_attributePayload_Merge.Value;
                requestAttributePayloadIsNull = false;
            }
             // determine if request.AttributePayload should be set to null
            if (requestAttributePayloadIsNull)
            {
                request.AttributePayload = null;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            if (cmdletContext.RemoveThingType != null)
            {
                request.RemoveThingType = cmdletContext.RemoveThingType.Value;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
            }
            if (cmdletContext.ThingTypeName != null)
            {
                request.ThingTypeName = cmdletContext.ThingTypeName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ThingName;
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
        
        private Amazon.IoT.Model.UpdateThingResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateThingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateThing");
            #if DESKTOP
            return client.UpdateThing(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateThingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> AttributePayload_Attributes { get; set; }
            public System.Boolean? AttributePayload_Merge { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.Boolean? RemoveThingType { get; set; }
            public System.String ThingName { get; set; }
            public System.String ThingTypeName { get; set; }
        }
        
    }
}
