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
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Retrieves S3Object instances for one or more S3 objects.
    /// </summary>
    [Cmdlet("Get", "S3Object", DefaultParameterSetName = ParamSet_MultipleObject)]
    [OutputType("Amazon.S3.Model.S3Object")]
    [AWSCmdlet("Lists your Amazon S3 objects in a bucket, returning a collection of S3Object metadata instances describing the objects."
                    + " Repeated calls are made to retrieve metadata for all objects unless a specific object key or key prefix and instance count limiters are specified."
                    , Operation = new [] {"ListObjects"})]
    [AWSCmdletOutput("Amazon.S3.Model.S3Object",
                     "This cmdlet returns 0 or more Amazon.S3.Model.S3Object instances.",
                     "The service response (type Amazon.S3.Model.ListObjectsRequest) is added to the cmdlet entry in the $AWSHistory stack for each call to retrieve output."
                            + " Additionally, the following properties are added as notes to the response instance: CommonPrefixes, Delimiter, MaxKeys, Prefix, NextMarker and IsTruncated."
    )]
    public class GetS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ParamSet_SingleObject = "GetSingleObject";
        const string ParamSet_MultipleObject = "GetMultipleObjects";

        #region Bucket/overall Params

        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket that holds the S3 object(s).
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter Encoding
        /// <summary>
        /// Requests Amazon S3 to encode the object keys in the response and specifies
        /// the encoding method to use. An object key may contain any Unicode character;
        /// however, XML 1.0 parser cannot parse some characters, such as characters
        /// with an ASCII value from 0 to 10. For characters that are not supported in
        /// XML 1.0, you can add this parameter to request that Amazon S3 encode the
        /// keys in the response.
        /// </summary>
        [Parameter(Mandatory = false)]
        [AWSConstantClassSource("Amazon.S3.EncodingType")]
        public Amazon.S3.EncodingType Encoding { get; set; }
        #endregion

        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }

        #endregion

        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }

        #endregion

        #endregion

        #region Single Object Identifier Parameters

        #region Parameter Key 
        /// <summary>
        /// Key value identifying a single object in S3 to return metadata for.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_SingleObject, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public System.String Key { get; set; }
        #endregion

        #endregion

        #region Multi-Object Identifier Parameters

        #region Parameter KeyPrefix
        /// <summary>
        /// Limits the response to keys which begin with the indicated prefix. You can 
        /// use prefixes to separate a bucket into different sets of keys in a way similar 
        /// to how a file system uses folders. If not specified, all objects are processed.
        /// </summary>
        [Alias("Prefix")]
        [Parameter(Position = 1, ParameterSetName = ParamSet_MultipleObject, ValueFromPipelineByPropertyName = true)]
        public System.String KeyPrefix { get; set; }
        #endregion

        #region Parameter Marker
        /// <summary>
        /// Indicates where in the bucket to begin listing. The list will only 
        /// include keys that occur lexicographically after marker. This is 
        /// convenient for pagination: to get the next page of results use the 
        /// last key of the current page as the marker.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_MultipleObject, ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion

        #region Parameter MaxKey
        /// <summary>
        /// <para>
        /// The maximum number of keys to return (the cmdlet might return fewer than this many keys, 
        /// but will not return more).
        /// </para>
        /// <para>
        /// Amazon S3 limits API calls to retrieve keys to a maximum of 1000 keys per call. If this 
        /// parameter is specified and exceeds this limit the cmdlet will make multiple calls in batches
        /// of 1000 to retrieve up to the specified number of keys (or less, depending  on how many objects 
        /// the bucket contains).
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_MultipleObject, ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems,MaxKeys")]
        public System.Int32? MaxKey { get; set; }
        #endregion

        #region Parameter Delimiter
        /// <summary>
        /// Causes keys that contain the same string between the prefix and the 
        /// first occurrence of the delimiter to be rolled up into a single result 
        /// element in the CommonPrefixes collection. These rolled-up keys are not 
        /// returned elsewhere in the response.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_MultipleObject, ValueFromPipelineByPropertyName = true)]
        public System.String Delimiter { get; set; }
        #endregion

        #endregion        

        // try and anticipate all the ways a user might mean 'get everything from root'
        readonly string[] rootIndicators = new string[] { "/", @"\", "*", "/*", @"\*" };

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName
            };

            // set the standard parameters
            if (this.ParameterSetName == ParamSet_SingleObject)
            {
                context.KeyPrefix = AmazonS3Helper.CleanKey(this.Key);
            }
            else
            {
                context.KeyPrefix = rootIndicators.Contains<string>(this.KeyPrefix, StringComparer.OrdinalIgnoreCase) 
                    ? null : AmazonS3Helper.CleanKey(this.KeyPrefix);
            }
            context.Marker = this.Marker;
            context.MaxKeys = this.MaxKey;
            context.Delimiter = this.Delimiter;
            context.Encoding = this.Encoding;

            // due to paging, output is handled within executor
            Execute(context);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new ListObjectsRequest { BucketName = cmdletContext.BucketName, Encoding = cmdletContext.Encoding };

            // loop invariants
            if (!string.IsNullOrEmpty(cmdletContext.KeyPrefix))
                request.Prefix = cmdletContext.KeyPrefix;
            if (!string.IsNullOrEmpty(cmdletContext.Delimiter))
                request.Delimiter = cmdletContext.Delimiter;

            string nextMarker = cmdletContext.Marker;
            int keysEmitted = 0;
            const int maxKeysPerCall = 1000; // s3's hard limit

            try
            {
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                bool isDone = false;
                do
                {
                    if (!string.IsNullOrEmpty(nextMarker))
                        request.Marker = nextMarker;

                    if (cmdletContext.MaxKeys.HasValue)
                    {
                        int remaining = cmdletContext.MaxKeys.Value - keysEmitted;
                        request.MaxKeys = remaining > maxKeysPerCall ? maxKeysPerCall : remaining;
                    }

                    CmdletOutput output;
                    try
                    {
                        var response = CallAWSServiceOperation(client, request);
                        object pipelineOutput = response.S3Objects;
                        int keysRetrieved = response.S3Objects.Count;

                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response
                        };

                        keysEmitted += keysRetrieved;
                        WriteProgressRecord("Retrieving", string.Format("Retrieved {0} keys starting from marker '{1}' in bucket '{2}'", keysRetrieved, nextMarker, cmdletContext.BucketName));
                        nextMarker = response.NextMarker;

                        // exit considerations
                        if (cmdletContext.MaxKeys.HasValue && keysEmitted >= cmdletContext.MaxKeys.Value)
                            isDone = true;

                        if (!response.IsTruncated)
                            isDone = true;
                    }
                    catch (AmazonS3Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }

                    ProcessOutput(output);
                } while (!isDone);
            }
            finally
            {
                WriteProgressCompleteRecord("Retrieving", "Retrieved records");
            }

            return null;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.S3.Model.ListObjectsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListObjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "ListObjects");

            try
            {
#if DESKTOP
                return client.ListObjects(request);
#elif CORECLR
                return client.ListObjectsAsync(request).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
            public String KeyPrefix { get; set; }
            public string Marker { get; set; }
            public int? MaxKeys { get; set; }
            public string Delimiter { get; set; }
            public EncodingType Encoding { get; set; }
        }
    }
}
