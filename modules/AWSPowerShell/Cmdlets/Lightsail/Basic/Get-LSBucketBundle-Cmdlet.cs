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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns the bundles that you can apply to a Amazon Lightsail bucket.
    /// 
    ///  
    /// <para>
    /// The bucket bundle specifies the monthly cost, storage quota, and data transfer quota
    /// for a bucket.
    /// </para><para>
    /// Use the <a>UpdateBucketBundle</a> action to update the bundle for a bucket.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LSBucketBundle")]
    [OutputType("Amazon.Lightsail.Model.BucketBundle")]
    [AWSCmdlet("Calls the Amazon Lightsail GetBucketBundles API operation.", Operation = new[] {"GetBucketBundles"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetBucketBundlesResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.BucketBundle or Amazon.Lightsail.Model.GetBucketBundlesResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.BucketBundle objects.",
        "The service call response (type Amazon.Lightsail.Model.GetBucketBundlesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSBucketBundleCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeInactive
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether to include inactive (unavailable) bundles in
        /// the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? IncludeInactive { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Bundles'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetBucketBundlesResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetBucketBundlesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Bundles";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IncludeInactive parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IncludeInactive' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IncludeInactive' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetBucketBundlesResponse, GetLSBucketBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IncludeInactive;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncludeInactive = this.IncludeInactive;
            
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
            var request = new Amazon.Lightsail.Model.GetBucketBundlesRequest();
            
            if (cmdletContext.IncludeInactive != null)
            {
                request.IncludeInactive = cmdletContext.IncludeInactive.Value;
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
        
        private Amazon.Lightsail.Model.GetBucketBundlesResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetBucketBundlesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetBucketBundles");
            try
            {
                #if DESKTOP
                return client.GetBucketBundles(request);
                #elif CORECLR
                return client.GetBucketBundlesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeInactive { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetBucketBundlesResponse, GetLSBucketBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Bundles;
        }
        
    }
}
