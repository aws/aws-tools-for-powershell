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
using Amazon.MediaStoreData;
using Amazon.MediaStoreData.Model;

namespace Amazon.PowerShell.Cmdlets.EMSD
{
    /// <summary>
    /// Downloads the object at the specified path.
    /// </summary>
    [Cmdlet("Get", "EMSDObject")]
    [OutputType("Amazon.MediaStoreData.Model.GetObjectResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore Data Plane GetObject API operation.", Operation = new[] {"GetObject"})]
    [AWSCmdletOutput("Amazon.MediaStoreData.Model.GetObjectResponse",
        "This cmdlet returns a Amazon.MediaStoreData.Model.GetObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEMSDObjectCmdlet : AmazonMediaStoreDataClientCmdlet, IExecutor
    {
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path (including the file name) where the object is stored in the container. Format:
        /// &lt;folder name&gt;/&lt;folder name&gt;/&lt;file name&gt;</para><para>For example, to upload the file <code>mlaw.avi</code> to the folder path <code>premium\canada</code>
        /// in the container <code>movies</code>, enter the path <code>premium/canada/mlaw.avi</code>.</para><para>Do not include the container name in this path.</para><para>If the path includes any folders that don't exist yet, the service creates them. For
        /// example, suppose you have an existing <code>premium/usa</code> subfolder. If you specify
        /// <code>premium/canada</code>, the service creates a <code>canada</code> subfolder in
        /// the <code>premium</code> folder. You then have two subfolders, <code>usa</code> and
        /// <code>canada</code>, in the <code>premium</code> folder. </para><para>There is no correlation between the path to the source and the path (folders) in the
        /// container in AWS Elemental MediaStore.</para><para>For more information about folders and how they exist in a container, see the <a href="http://docs.aws.amazon.com/mediastore/latest/ug/">AWS
        /// Elemental MediaStore User Guide</a>.</para><para>The file name is the name that is assigned to the file that you upload. The file can
        /// have the same name inside and outside of AWS Elemental MediaStore, or it can have
        /// the same name. The file name can include or omit an extension. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Range
        /// <summary>
        /// <para>
        /// <para>The range bytes of an object to retrieve. For more information about the <code>Range</code>
        /// header, go to <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.35">http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.35</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Range { get; set; }
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
            
            context.Path = this.Path;
            context.Range = this.Range;
            
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
            var request = new Amazon.MediaStoreData.Model.GetObjectRequest();
            
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Range != null)
            {
                request.Range = cmdletContext.Range;
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
        
        private Amazon.MediaStoreData.Model.GetObjectResponse CallAWSServiceOperation(IAmazonMediaStoreData client, Amazon.MediaStoreData.Model.GetObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaStore Data Plane", "GetObject");
            try
            {
                #if DESKTOP
                return client.GetObject(request);
                #elif CORECLR
                return client.GetObjectAsync(request).GetAwaiter().GetResult();
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
            public System.String Path { get; set; }
            public System.String Range { get; set; }
        }
        
    }
}
