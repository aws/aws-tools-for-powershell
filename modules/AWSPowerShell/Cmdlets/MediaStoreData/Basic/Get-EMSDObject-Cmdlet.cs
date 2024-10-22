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
using Amazon.MediaStoreData;
using Amazon.MediaStoreData.Model;

namespace Amazon.PowerShell.Cmdlets.EMSD
{
    /// <summary>
    /// Downloads the object at the specified path. If the object’s upload availability is
    /// set to <c>streaming</c>, AWS Elemental MediaStore downloads the object even if it’s
    /// still uploading the object.
    /// </summary>
    [Cmdlet("Get", "EMSDObject")]
    [OutputType("Amazon.MediaStoreData.Model.GetObjectResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaStore Data Plane GetObject API operation.", Operation = new[] {"GetObject"}, SelectReturnType = typeof(Amazon.MediaStoreData.Model.GetObjectResponse))]
    [AWSCmdletOutput("Amazon.MediaStoreData.Model.GetObjectResponse",
        "This cmdlet returns an Amazon.MediaStoreData.Model.GetObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEMSDObjectCmdlet : AmazonMediaStoreDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path (including the file name) where the object is stored in the container. Format:
        /// &lt;folder name&gt;/&lt;folder name&gt;/&lt;file name&gt;</para><para>For example, to upload the file <c>mlaw.avi</c> to the folder path <c>premium\canada</c>
        /// in the container <c>movies</c>, enter the path <c>premium/canada/mlaw.avi</c>.</para><para>Do not include the container name in this path.</para><para>If the path includes any folders that don't exist yet, the service creates them. For
        /// example, suppose you have an existing <c>premium/usa</c> subfolder. If you specify
        /// <c>premium/canada</c>, the service creates a <c>canada</c> subfolder in the <c>premium</c>
        /// folder. You then have two subfolders, <c>usa</c> and <c>canada</c>, in the <c>premium</c>
        /// folder. </para><para>There is no correlation between the path to the source and the path (folders) in the
        /// container in AWS Elemental MediaStore.</para><para>For more information about folders and how they exist in a container, see the <a href="http://docs.aws.amazon.com/mediastore/latest/ug/">AWS
        /// Elemental MediaStore User Guide</a>.</para><para>The file name is the name that is assigned to the file that you upload. The file can
        /// have the same name inside and outside of AWS Elemental MediaStore, or it can have
        /// the same name. The file name can include or omit an extension. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Range
        /// <summary>
        /// <para>
        /// <para>The range bytes of an object to retrieve. For more information about the <c>Range</c>
        /// header, see <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.35">http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.35</a>.
        /// AWS Elemental MediaStore ignores this header for partially uploaded objects that have
        /// streaming upload availability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Range { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaStoreData.Model.GetObjectResponse).
        /// Specifying the name of a property of type Amazon.MediaStoreData.Model.GetObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaStoreData.Model.GetObjectResponse, GetEMSDObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            public System.Func<Amazon.MediaStoreData.Model.GetObjectResponse, GetEMSDObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
