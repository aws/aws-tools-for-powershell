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
    /// Creates a thing in the thing registry.
    /// </summary>
    [Cmdlet("New", "IOTThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingResponse")]
    [AWSCmdlet("Invokes the CreateThing operation against AWS IoT.", Operation = new[] {"CreateThing"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateThingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewIOTThingCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A JSON string containing up to three key-value pair in JSON format.</para><para>For example: {\"attributes\":{\"string1\":\"string2\”}}</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AttributePayload_Attributes")]
        public System.Collections.Hashtable AttributePayload_Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingName { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ThingName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTThing (CreateThing)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AttributePayload_Attribute != null)
            {
                context.AttributePayload_Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributePayload_Attribute.Keys)
                {
                    context.AttributePayload_Attributes.Add((String)hashKey, (String)(this.AttributePayload_Attribute[hashKey]));
                }
            }
            context.ThingName = this.ThingName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IoT.Model.CreateThingRequest();
            
            
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
             // determine if request.AttributePayload should be set to null
            if (requestAttributePayloadIsNull)
            {
                request.AttributePayload = null;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateThing(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> AttributePayload_Attributes { get; set; }
            public System.String ThingName { get; set; }
        }
        
    }
}
