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
    /// 
    ///  <note><para>
    /// This is a control plane operation. See <a href="http://docs.aws.amazon.com/iot/latest/developerguide/authorization.html">Authorization</a>
    /// for information about authorizing control plane actions.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IOTThingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateThingGroupResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateThingGroup API operation.", Operation = new[] {"CreateThingGroup"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateThingGroupResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateThingGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTThingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ThingGroupProperties_AttributePayload
        /// <summary>
        /// <para>
        /// <para>The thing group attributes in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
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
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            context.ThingGroupName = this.ThingGroupName;
            context.ThingGroupProperties_AttributePayload = this.ThingGroupProperties_AttributePayload;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.ThingGroupName != null)
            {
                request.ThingGroupName = cmdletContext.ThingGroupName;
            }
            
             // populate ThingGroupProperties
            bool requestThingGroupPropertiesIsNull = true;
            request.ThingGroupProperties = new Amazon.IoT.Model.ThingGroupProperties();
            Amazon.IoT.Model.AttributePayload requestThingGroupProperties_thingGroupProperties_AttributePayload = null;
            if (cmdletContext.ThingGroupProperties_AttributePayload != null)
            {
                requestThingGroupProperties_thingGroupProperties_AttributePayload = cmdletContext.ThingGroupProperties_AttributePayload;
            }
            if (requestThingGroupProperties_thingGroupProperties_AttributePayload != null)
            {
                request.ThingGroupProperties.AttributePayload = requestThingGroupProperties_thingGroupProperties_AttributePayload;
                requestThingGroupPropertiesIsNull = false;
            }
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
            public List<Amazon.IoT.Model.Tag> Tags { get; set; }
            public System.String ThingGroupName { get; set; }
            public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
            public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
        }
        
    }
}
