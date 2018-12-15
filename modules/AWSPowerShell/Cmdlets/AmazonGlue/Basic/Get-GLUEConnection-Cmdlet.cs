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
    /// Retrieves a connection definition from the Data Catalog.
    /// </summary>
    [Cmdlet("Get", "GLUEConnection")]
    [OutputType("Amazon.Glue.Model.Connection")]
    [AWSCmdlet("Calls the AWS Glue GetConnection API operation.", Operation = new[] {"GetConnection"})]
    [AWSCmdletOutput("Amazon.Glue.Model.Connection",
        "This cmdlet returns a Connection object.",
        "The service call response (type Amazon.Glue.Model.GetConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEConnectionCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog in which the connection resides. If none is supplied, the
        /// AWS account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter HidePassword
        /// <summary>
        /// <para>
        /// <para>Allow you to retrieve the connection metadata without displaying the password. For
        /// instance, the AWS Glue console uses this flag to retrieve connections, since the console
        /// does not display passwords. Set this parameter where the caller may not have permission
        /// to use the KMS key to decrypt the password, but does have permission to access the
        /// rest of the connection metadata (that is, the other connection properties).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HidePassword { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the connection definition to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
            
            context.CatalogId = this.CatalogId;
            if (ParameterWasBound("HidePassword"))
                context.HidePassword = this.HidePassword;
            context.Name = this.Name;
            
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
            var request = new Amazon.Glue.Model.GetConnectionRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.HidePassword != null)
            {
                request.HidePassword = cmdletContext.HidePassword.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Connection;
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
        
        private Amazon.Glue.Model.GetConnectionResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetConnection");
            try
            {
                #if DESKTOP
                return client.GetConnection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetConnectionAsync(request);
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
            public System.String CatalogId { get; set; }
            public System.Boolean? HidePassword { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
