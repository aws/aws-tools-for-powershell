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
using Amazon.CloudHSM;
using Amazon.CloudHSM.Model;

namespace Amazon.PowerShell.Cmdlets.HSM
{
    /// <summary>
    /// Gets the configuration files necessary to connect to all high availability partition
    /// groups the client is associated with.
    /// </summary>
    [Cmdlet("Get", "HSMConfig")]
    [OutputType("Amazon.CloudHSM.Model.GetConfigResponse")]
    [AWSCmdlet("Invokes the GetConfig operation against AWS Cloud HSM.", Operation = new[] {"GetConfig"})]
    [AWSCmdletOutput("Amazon.CloudHSM.Model.GetConfigResponse",
        "This cmdlet returns a Amazon.CloudHSM.Model.GetConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetHSMConfigCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        #region Parameter ClientArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClientArn { get; set; }
        #endregion
        
        #region Parameter ClientVersion
        /// <summary>
        /// <para>
        /// <para>The client version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudHSM.ClientVersion")]
        public Amazon.CloudHSM.ClientVersion ClientVersion { get; set; }
        #endregion
        
        #region Parameter HapgList
        /// <summary>
        /// <para>
        /// <para>A list of ARNs that identify the high-availability partition groups that are associated
        /// with the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] HapgList { get; set; }
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
            
            context.ClientArn = this.ClientArn;
            context.ClientVersion = this.ClientVersion;
            if (this.HapgList != null)
            {
                context.HapgList = new List<System.String>(this.HapgList);
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
            var request = new Amazon.CloudHSM.Model.GetConfigRequest();
            
            if (cmdletContext.ClientArn != null)
            {
                request.ClientArn = cmdletContext.ClientArn;
            }
            if (cmdletContext.ClientVersion != null)
            {
                request.ClientVersion = cmdletContext.ClientVersion;
            }
            if (cmdletContext.HapgList != null)
            {
                request.HapgList = cmdletContext.HapgList;
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
        
        private static Amazon.CloudHSM.Model.GetConfigResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.GetConfigRequest request)
        {
            #if DESKTOP
            return client.GetConfig(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetConfigAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientArn { get; set; }
            public Amazon.CloudHSM.ClientVersion ClientVersion { get; set; }
            public List<System.String> HapgList { get; set; }
        }
        
    }
}
