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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new DevEndpoint.
    /// </summary>
    [Cmdlet("New", "GLUEDevEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateDevEndpointResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateDevEndpoint API operation.", Operation = new[] {"CreateDevEndpoint"})]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateDevEndpointResponse",
        "This cmdlet returns a Amazon.Glue.Model.CreateDevEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEDevEndpointCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name to be assigned to the new DevEndpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter ExtraJarsS3Path
        /// <summary>
        /// <para>
        /// <para>Path to one or more Java Jars in an S3 bucket that should be loaded in your DevEndpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExtraJarsS3Path { get; set; }
        #endregion
        
        #region Parameter ExtraPythonLibsS3Path
        /// <summary>
        /// <para>
        /// <para>Path(s) to one or more Python libraries in an S3 bucket that should be loaded in your
        /// DevEndpoint. Multiple values must be complete paths separated by a comma.</para><para>Please note that only pure Python libraries can currently be used on a DevEndpoint.
        /// Libraries that rely on C extensions, such as the <a href="http://pandas.pydata.org/">pandas</a>
        /// Python data analysis library, are not yet supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExtraPythonLibsS3Path { get; set; }
        #endregion
        
        #region Parameter NumberOfNode
        /// <summary>
        /// <para>
        /// <para>The number of AWS Glue Data Processing Units (DPUs) to allocate to this DevEndpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumberOfNodes")]
        public System.Int32 NumberOfNode { get; set; }
        #endregion
        
        #region Parameter PublicKey
        /// <summary>
        /// <para>
        /// <para>The public key to use for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PublicKey { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role for the DevEndpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Security group IDs for the security groups to be used by the new DevEndpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet ID for the new DevEndpoint to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubnetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EndpointName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEDevEndpoint (CreateDevEndpoint)"))
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
            
            context.EndpointName = this.EndpointName;
            context.ExtraJarsS3Path = this.ExtraJarsS3Path;
            context.ExtraPythonLibsS3Path = this.ExtraPythonLibsS3Path;
            if (ParameterWasBound("NumberOfNode"))
                context.NumberOfNodes = this.NumberOfNode;
            context.PublicKey = this.PublicKey;
            context.RoleArn = this.RoleArn;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            context.SubnetId = this.SubnetId;
            
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
            var request = new Amazon.Glue.Model.CreateDevEndpointRequest();
            
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.ExtraJarsS3Path != null)
            {
                request.ExtraJarsS3Path = cmdletContext.ExtraJarsS3Path;
            }
            if (cmdletContext.ExtraPythonLibsS3Path != null)
            {
                request.ExtraPythonLibsS3Path = cmdletContext.ExtraPythonLibsS3Path;
            }
            if (cmdletContext.NumberOfNodes != null)
            {
                request.NumberOfNodes = cmdletContext.NumberOfNodes.Value;
            }
            if (cmdletContext.PublicKey != null)
            {
                request.PublicKey = cmdletContext.PublicKey;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.Glue.Model.CreateDevEndpointResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateDevEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateDevEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateDevEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDevEndpointAsync(request);
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
            public System.String EndpointName { get; set; }
            public System.String ExtraJarsS3Path { get; set; }
            public System.String ExtraPythonLibsS3Path { get; set; }
            public System.Int32? NumberOfNodes { get; set; }
            public System.String PublicKey { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public System.String SubnetId { get; set; }
        }
        
    }
}
