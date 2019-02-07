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
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// Creates a robot application.
    /// </summary>
    [Cmdlet("New", "ROBORobotApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.CreateRobotApplicationResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker CreateRobotApplication API operation.", Operation = new[] {"CreateRobotApplication"})]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.CreateRobotApplicationResponse",
        "This cmdlet returns a Amazon.RoboMaker.Model.CreateRobotApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewROBORobotApplicationCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RobotSoftwareSuite
        /// <summary>
        /// <para>
        /// <para>The robot software suite used by the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The sources of the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Sources")]
        public Amazon.RoboMaker.Model.SourceConfig[] Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values that are attached to the robot application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ROBORobotApplication (CreateRobotApplication)"))
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
            
            context.Name = this.Name;
            context.RobotSoftwareSuite = this.RobotSoftwareSuite;
            if (this.Source != null)
            {
                context.Sources = new List<Amazon.RoboMaker.Model.SourceConfig>(this.Source);
            }
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.RoboMaker.Model.CreateRobotApplicationRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RobotSoftwareSuite != null)
            {
                request.RobotSoftwareSuite = cmdletContext.RobotSoftwareSuite;
            }
            if (cmdletContext.Sources != null)
            {
                request.Sources = cmdletContext.Sources;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
        
        private Amazon.RoboMaker.Model.CreateRobotApplicationResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.CreateRobotApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "CreateRobotApplication");
            try
            {
                #if DESKTOP
                return client.CreateRobotApplication(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRobotApplicationAsync(request);
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
            public System.String Name { get; set; }
            public Amazon.RoboMaker.Model.RobotSoftwareSuite RobotSoftwareSuite { get; set; }
            public List<Amazon.RoboMaker.Model.SourceConfig> Sources { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
