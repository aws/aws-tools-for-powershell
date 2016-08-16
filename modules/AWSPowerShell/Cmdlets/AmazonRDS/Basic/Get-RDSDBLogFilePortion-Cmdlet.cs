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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Downloads all or a portion of the specified log file, up to 1 MB in size.
    /// </summary>
    [Cmdlet("Get", "RDSDBLogFilePortion")]
    [OutputType("Amazon.RDS.Model.DownloadDBLogFilePortionResponse")]
    [AWSCmdlet("Invokes the DownloadDBLogFilePortion operation against Amazon Relational Database Service.", Operation = new[] {"DownloadDBLogFilePortion"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DownloadDBLogFilePortionResponse",
        "This cmdlet returns a Amazon.RDS.Model.DownloadDBLogFilePortionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRDSDBLogFilePortionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The customer-assigned name of the DB instance that contains the log files you want
        /// to list.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter LogFileName
        /// <summary>
        /// <para>
        /// <para>The name of the log file to be downloaded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String LogFileName { get; set; }
        #endregion
        
        #region Parameter NumberOfLines
        /// <summary>
        /// <para>
        /// <para>The number of lines to download. If the number of lines specified results in a file
        /// over 1 MB in size, the file will be truncated at 1 MB in size.</para><para>If the NumberOfLines parameter is specified, then the block of lines returned can
        /// be from the beginning or the end of the log file, depending on the value of the Marker
        /// parameter.</para><ul><li><para>If neither Marker or NumberOfLines are specified, the entire log file is returned
        /// up to a maximum of 10000 lines, starting with the most recent log entries first.</para></li><li><para>If NumberOfLines is specified and Marker is not specified, then the most recent lines
        /// from the end of the log file are returned.</para></li><li><para>If Marker is specified as "0", then the specified number of lines from the beginning
        /// of the log file are returned.</para></li><li><para>You can download the log file in blocks of lines by specifying the size of the block
        /// using the NumberOfLines parameter, and by specifying a value of "0" for the Marker
        /// parameter in your first request. Include the Marker value returned in the response
        /// as the Marker value for the next request, continuing until the AdditionalDataPending
        /// response element returns false.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfLines { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token provided in the previous request or "0". If the Marker parameter
        /// is specified the response includes only records beyond the marker until the end of
        /// the file or up to NumberOfLines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
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
            
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.LogFileName = this.LogFileName;
            context.Marker = this.Marker;
            if (ParameterWasBound("NumberOfLines"))
                context.NumberOfLines = this.NumberOfLines;
            
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
            var request = new Amazon.RDS.Model.DownloadDBLogFilePortionRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.LogFileName != null)
            {
                request.LogFileName = cmdletContext.LogFileName;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.NumberOfLines != null)
            {
                request.NumberOfLines = cmdletContext.NumberOfLines.Value;
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
        
        private static Amazon.RDS.Model.DownloadDBLogFilePortionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DownloadDBLogFilePortionRequest request)
        {
            #if DESKTOP
            return client.DownloadDBLogFilePortion(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DownloadDBLogFilePortionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DBInstanceIdentifier { get; set; }
            public System.String LogFileName { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? NumberOfLines { get; set; }
        }
        
    }
}
