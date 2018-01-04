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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Gets room skill parameter details by room, skill, and parameter key ARN.
    /// </summary>
    [Cmdlet("Get", "ALXBRoomSkillParameter")]
    [OutputType("Amazon.AlexaForBusiness.Model.RoomSkillParameter")]
    [AWSCmdlet("Calls the Alexa For Business GetRoomSkillParameter API operation.", Operation = new[] {"GetRoomSkillParameter"})]
    [AWSCmdletOutput("Amazon.AlexaForBusiness.Model.RoomSkillParameter",
        "This cmdlet returns a RoomSkillParameter object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.GetRoomSkillParameterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetALXBRoomSkillParameterCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter ParameterKey
        /// <summary>
        /// <para>
        /// <para>The room skill parameter key for which to get details. Required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ParameterKey { get; set; }
        #endregion
        
        #region Parameter RoomArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the room from which to get the room skill parameter details. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoomArn { get; set; }
        #endregion
        
        #region Parameter SkillId
        /// <summary>
        /// <para>
        /// <para>The ARN of the skill from which to get the room skill parameter details. Required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SkillId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ParameterKey = this.ParameterKey;
            context.RoomArn = this.RoomArn;
            context.SkillId = this.SkillId;
            
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
            var request = new Amazon.AlexaForBusiness.Model.GetRoomSkillParameterRequest();
            
            if (cmdletContext.ParameterKey != null)
            {
                request.ParameterKey = cmdletContext.ParameterKey;
            }
            if (cmdletContext.RoomArn != null)
            {
                request.RoomArn = cmdletContext.RoomArn;
            }
            if (cmdletContext.SkillId != null)
            {
                request.SkillId = cmdletContext.SkillId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RoomSkillParameter;
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
        
        private Amazon.AlexaForBusiness.Model.GetRoomSkillParameterResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.GetRoomSkillParameterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "GetRoomSkillParameter");
            try
            {
                #if DESKTOP
                return client.GetRoomSkillParameter(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetRoomSkillParameterAsync(request);
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
            public System.String ParameterKey { get; set; }
            public System.String RoomArn { get; set; }
            public System.String SkillId { get; set; }
        }
        
    }
}
