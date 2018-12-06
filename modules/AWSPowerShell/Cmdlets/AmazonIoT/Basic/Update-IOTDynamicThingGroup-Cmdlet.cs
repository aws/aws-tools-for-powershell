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
    /// Updates a dynamic thing group.
    /// </summary>
    [Cmdlet("Update", "IOTDynamicThingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS IoT UpdateDynamicThingGroup API operation.", Operation = new[] {"UpdateDynamicThingGroup"})]
    [AWSCmdletOutput("System.Int64",
        "This cmdlet returns a Int64 object.",
        "The service call response (type Amazon.IoT.Model.UpdateDynamicThingGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTDynamicThingGroupCmdlet : AmazonIoTClientCmdlet, IExecutor
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
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the dynamic thing group to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The dynamic thing group index to update.</para><note><para>Currently one index is supported: 'AWS_Things'.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The dynamic thing group search query string to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter QueryVersion
        /// <summary>
        /// <para>
        /// <para>The dynamic thing group query version to update.</para><note><para>Currently one query version is supported: "2017-09-30". If not specified, the query
        /// version defaults to this value.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QueryVersion { get; set; }
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
        /// <para>The name of the dynamic thing group to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTDynamicThingGroup (UpdateDynamicThingGroup)"))
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
            
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            context.IndexName = this.IndexName;
            context.QueryString = this.QueryString;
            context.QueryVersion = this.QueryVersion;
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
            var request = new Amazon.IoT.Model.UpdateDynamicThingGroupRequest();
            
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            if (cmdletContext.QueryVersion != null)
            {
                request.QueryVersion = cmdletContext.QueryVersion;
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
                object pipelineOutput = response.Version;
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
        
        private Amazon.IoT.Model.UpdateDynamicThingGroupResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateDynamicThingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateDynamicThingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateDynamicThingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateDynamicThingGroupAsync(request);
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
            public System.Int64? ExpectedVersion { get; set; }
            public System.String IndexName { get; set; }
            public System.String QueryString { get; set; }
            public System.String QueryVersion { get; set; }
            public System.String ThingGroupName { get; set; }
            public Amazon.IoT.Model.AttributePayload ThingGroupProperties_AttributePayload { get; set; }
            public System.String ThingGroupProperties_ThingGroupDescription { get; set; }
        }
        
    }
}
