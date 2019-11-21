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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates the groups to which the thing belongs.
    /// </summary>
    [Cmdlet("Update", "IOTThingGroupsForThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateThingGroupsForThing API operation.", Operation = new[] {"UpdateThingGroupsForThing"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateThingGroupsForThingResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateThingGroupsForThingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateThingGroupsForThingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTThingGroupsForThingCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter OverrideDynamicGroup
        /// <summary>
        /// <para>
        /// <para>Override dynamic thing groups with static thing groups when 10-group limit is reached.
        /// If a thing belongs to 10 thing groups, and one or more of those groups are dynamic
        /// thing groups, adding a thing to a static group removes the thing from the last dynamic
        /// group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideDynamicGroups")]
        public System.Boolean? OverrideDynamicGroup { get; set; }
        #endregion
        
        #region Parameter ThingGroupsToAdd
        /// <summary>
        /// <para>
        /// <para>The groups to which the thing will be added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ThingGroupsToAdd { get; set; }
        #endregion
        
        #region Parameter ThingGroupsToRemove
        /// <summary>
        /// <para>
        /// <para>The groups from which the thing will be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ThingGroupsToRemove { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The thing whose group memberships will be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateThingGroupsForThingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTThingGroupsForThing (UpdateThingGroupsForThing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateThingGroupsForThingResponse, UpdateIOTThingGroupsForThingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OverrideDynamicGroup = this.OverrideDynamicGroup;
            if (this.ThingGroupsToAdd != null)
            {
                context.ThingGroupsToAdd = new List<System.String>(this.ThingGroupsToAdd);
            }
            if (this.ThingGroupsToRemove != null)
            {
                context.ThingGroupsToRemove = new List<System.String>(this.ThingGroupsToRemove);
            }
            context.ThingName = this.ThingName;
            
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
            var request = new Amazon.IoT.Model.UpdateThingGroupsForThingRequest();
            
            if (cmdletContext.OverrideDynamicGroup != null)
            {
                request.OverrideDynamicGroups = cmdletContext.OverrideDynamicGroup.Value;
            }
            if (cmdletContext.ThingGroupsToAdd != null)
            {
                request.ThingGroupsToAdd = cmdletContext.ThingGroupsToAdd;
            }
            if (cmdletContext.ThingGroupsToRemove != null)
            {
                request.ThingGroupsToRemove = cmdletContext.ThingGroupsToRemove;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
        
        private Amazon.IoT.Model.UpdateThingGroupsForThingResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateThingGroupsForThingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateThingGroupsForThing");
            try
            {
                #if DESKTOP
                return client.UpdateThingGroupsForThing(request);
                #elif CORECLR
                return client.UpdateThingGroupsForThingAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? OverrideDynamicGroup { get; set; }
            public List<System.String> ThingGroupsToAdd { get; set; }
            public List<System.String> ThingGroupsToRemove { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateThingGroupsForThingResponse, UpdateIOTThingGroupsForThingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
