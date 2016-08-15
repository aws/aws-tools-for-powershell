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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Returns a <code>DataSource</code> that includes metadata and data file information,
    /// as well as the current status of the <code>DataSource</code>.
    /// 
    ///  
    /// <para><code>GetDataSource</code> provides results in normal or verbose format. The verbose
    /// format adds the schema description and the list of files pointed to by the DataSource
    /// to the normal format.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "MLDataSource")]
    [OutputType("Amazon.MachineLearning.Model.GetDataSourceResponse")]
    [AWSCmdlet("Invokes the GetDataSource operation against Amazon Machine Learning.", Operation = new[] {"GetDataSource"})]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.GetDataSourceResponse",
        "This cmdlet returns a Amazon.MachineLearning.Model.GetDataSourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMLDataSourceCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>DataSource</code> at creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter VerboseResponse
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <code>GetDataSource</code> operation should return <code>DataSourceSchema</code>.</para><para>If true, <code>DataSourceSchema</code> is returned.</para><para>If false, <code>DataSourceSchema</code> is not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean VerboseResponse { get; set; }
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
            
            context.DataSourceId = this.DataSourceId;
            if (ParameterWasBound("VerboseResponse"))
                context.VerboseResponse = this.VerboseResponse;
            
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
            var request = new Amazon.MachineLearning.Model.GetDataSourceRequest();
            
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            if (cmdletContext.VerboseResponse != null)
            {
                request.Verbose = cmdletContext.VerboseResponse.Value;
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
        
        private static Amazon.MachineLearning.Model.GetDataSourceResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.GetDataSourceRequest request)
        {
            #if DESKTOP
            return client.GetDataSource(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDataSourceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DataSourceId { get; set; }
            public System.Boolean? VerboseResponse { get; set; }
        }
        
    }
}
