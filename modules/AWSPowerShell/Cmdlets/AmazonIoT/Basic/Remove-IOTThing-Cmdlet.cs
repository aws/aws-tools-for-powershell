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
    /// Deletes the specified thing.
    /// </summary>
    [Cmdlet("Remove", "IOTThing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DeleteThing operation against AWS IoT.", Operation = new[] {"DeleteThing"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ThingName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.DeleteThingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveIOTThingCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The expected version of the thing record in the registry. If the version of the record
        /// in the registry does not match the expected version specified in the request, the
        /// <code>DeleteThing</code> request is rejected with a <code>VersionConflictException</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the thing to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTThing (DeleteThing)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            context.ThingName = this.ThingName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IoT.Model.DeleteThingRequest();
            
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
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
        
        private static Amazon.IoT.Model.DeleteThingResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.DeleteThingRequest request)
        {
            return client.DeleteThing(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int64? ExpectedVersion { get; set; }
            public System.String ThingName { get; set; }
        }
        
    }
}
